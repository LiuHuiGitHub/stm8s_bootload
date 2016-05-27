using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Utilities.IO;

namespace stm8s_bootload
{
    public partial class stm8s_bootload : Form
    {
        SerialPort Comm = new SerialPort();

        const string appName = "stm8s_bootload";
        const uint c_u32_appAddr = 0x8000;
        const uint c_u32_bootLoadAddr = 0x9F00;
        const uint c_u32_mcuSize = 64;

        uint u32_resetAddr = 0;
        
        byte[] readyCmd = { };
        byte[] boot = { };
        byte[] appArray = { };

        public stm8s_bootload()
        {
            InitializeComponent();
            settingForm(false);
            Text = appName;
        }

        #region SerialPort
        private bool SerialPortOpen(string com, string baud)
        {
            try
            {
                Comm.PortName = com;
                Comm.BaudRate = int.Parse(baud);
                Comm.Parity = Parity.None;
                Comm.StopBits = StopBits.One;
                Comm.DataBits = 8;

                Comm.WriteTimeout = 1000;
                Comm.ReadTimeout = 1000;
                Comm.NewLine = "\r\n";      //新行的文本，用于WriteLine方法中由系统附加在text后 

                Comm.Open();

                progressBar.Enabled = false;
                return true;
            }
            catch
            {
            }
            return false;
        }

        private void SerialPortClose()
        {
            Comm.Close();
            progressBar.Enabled = true;
        }

        int commReadData(out byte[] bytes)
        {
            bytes = new byte[Comm.BytesToRead];
            Comm.Read(bytes, 0, bytes.Length);
            //TextBoxShowString(textBoxMessage, "Rx:" + ByteArrayToHexString(bytes, " "), "\r\n");
            return bytes.Length;
        }
        void commWriteData(byte[] bytes)
        {
            Comm.Write(bytes, 0, bytes.Length);
            //TextBoxShowString(textBoxMessage, "Tx:" + ByteArrayToHexString(bytes, " "), "\r\n");
        }

        #endregion

        #region File
        private void openHexFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fp_openFile = new OpenFileDialog();
            fp_openFile.Title = "打开APP文件";
            fp_openFile.Filter = "hex (*.hex)|*.hex|所有文件 (*.*)|*.*";
            if (fp_openFile.ShowDialog() == DialogResult.OK)
            {
                Text = appName + "  " + System.IO.Path.GetFileName(fp_openFile.FileName);

                HexFileStream tStream = null;
                try
                {
                    tStream = new HexFileStream(fp_openFile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    u32_resetAddr = tStream.StartLinearAddress;
                }
                catch (Exception Err)
                {
                    Err.ToString();
                    return;
                }
                appArray = new Byte[tStream.Length - c_u32_appAddr];
                tStream.Seek(c_u32_appAddr, SeekOrigin.Begin);
                tStream.Read(appArray, 0, appArray.Length);
                tStream.Close();
                buttonOpenFile.BackColor = Color.DeepSkyBlue;
            }
        }
        #endregion

        public static void delay_ms(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }

        int CRC16Byte(int crc16, byte x)
        {
            crc16 ^= x << 8;
            for (int i = 0; i < 8; i++)
            {
                crc16 = ((crc16 & 0x8000) != 0) ? (crc16 << 1 ^ 0x1621) : (crc16 << 1);
            }
            return crc16;
        }

        byte[] downLoadSector(byte[] bytes, byte cmd, uint sectorAddr)
        {
            byte[] txHex, hexReplace;
            int crc = 0;
            hexReplace = HexUtility.Replace(bytes, new byte[] { 0xEE }, new byte[] { 0xEE, 0xEE });
            hexReplace = HexUtility.Replace(hexReplace, new byte[] { 0xAA }, new byte[] { 0xEE, 0xEA });
            hexReplace = HexUtility.Replace(hexReplace, new byte[] { 0xCC }, new byte[] { 0xEE, 0xEC });

            txHex = new byte[hexReplace.Length + 12];
            txHex[3] = (byte)(bytes.Length >> 8);   //NumberH
            txHex[4] = (byte)(bytes.Length);        //NumberL
            txHex[5] = 64;                          //BlockSize
            txHex[6] = cmd;                         //Cmd
            txHex[7] = (byte)(sectorAddr >> 24);
            txHex[8] = (byte)(sectorAddr >> 16);
            txHex[9] = (byte)(sectorAddr >> 8);
            txHex[10] = (byte)(sectorAddr >> 0);
            Array.Copy(bytes, 0, txHex, 11, bytes.Length);
            for (int i = 0; i < bytes.Length + 8; i++)
            {
                crc = CRC16Byte(crc, txHex[i + 3]);
            }
            txHex[1] = (byte)(crc >> 8);            //CRC_H
            txHex[2] = (byte)(crc);                 //CRC_L
            Array.Copy(hexReplace, 0, txHex, 11, hexReplace.Length);
            txHex = HexUtility.Replace(txHex, new byte[] { 0xAA }, new byte[] { 0xEE, 0xEA });
            txHex = HexUtility.Replace(txHex, new byte[] { 0xCC }, new byte[] { 0xEE, 0xEC });
            txHex[0] = 0xAA;                        //Head
            txHex[txHex.Length - 1] = 0xCC;         //End
            return txHex;
        }

        bool downloadStep()
        {
            bool downloadFlag = true;
            byte[] respond;
            uint sectorIndex = 0;
            string fsm_downLoadStep = "fsm_downLoadReadyCmd";
            while (downloadFlag)
            {
                bool RecFlag = false;
                respond = new byte[] { };
                labelMessage.Text = fsm_downLoadStep;
                switch (fsm_downLoadStep)
                {
                    case "fsm_downLoadReadyCmd":
                        commWriteData(readyCmd);
                        fsm_downLoadStep = "fsm_resetToLoader";
                        break;

                    case "fsm_resetToLoader":
                        commWriteData(new byte[] { 0xAA, 0x3F, 0xD9, 0x00, 0x00, 0x80, 0xF5, 0x00, 0x00, 0x00, 0x00, 0xCC, 0xCC, 0xDD });
                        fsm_downLoadStep = "fsm_downLoadBootSector";
                        respond = new byte[] { 0xA9 };
                        break;

                    case "fsm_downLoadBootSector":
                        commWriteData(boot);
                        fsm_downLoadStep = "fsm_downLoadAppSector" + sectorIndex.ToString();
                        respond = new byte[] { 0xAC };
                        break;

                    case "fsm_downLoadAppResetAddr":
                        byte[] resetAddr = new byte[] { 0x82, 0x00, 0x82, 0x5F, 0xAA };
                        resetAddr[2] = (byte)(u32_resetAddr >> 8);
                        resetAddr[3] = (byte)(u32_resetAddr);
                        commWriteData(downLoadSector(resetAddr, 0xFE, 0));
                        fsm_downLoadStep = "fsm_downLoadAppComplete";
                        respond = new byte[] { 0xAB };
                        break;

                    case "fsm_downLoadAppComplete":
                        downloadFlag = false;
                        break;

                    default:
                        byte[] hex;
                        uint sectorAddr;
                        if (appArray.Length > (sectorIndex + 1) * c_u32_mcuSize)
                        {
                            hex = new byte[c_u32_mcuSize];
                        }
                        else
                        {
                            hex = new byte[appArray.Length - sectorIndex * c_u32_mcuSize];
                            RecFlag = true;
                        }
                        sectorAddr = c_u32_appAddr + c_u32_mcuSize * sectorIndex;
                        Array.Copy(appArray, sectorIndex * c_u32_mcuSize, hex, 0, hex.Length);
                        commWriteData(downLoadSector(hex, 0x00, sectorAddr));

                        if (RecFlag == true)
                        {
                            fsm_downLoadStep = "fsm_downLoadAppResetAddr";
                            respond = new byte[] { 0xA7 };
                        }
                        else
                        {
                            sectorIndex++;
                            fsm_downLoadStep = "fsm_downLoadAppSector" + sectorIndex.ToString();
                            respond = new byte[] { 0xA7 };
                        }
                        break;
                }
                if (downloadFlag)
                {
                    while (Comm.BytesToWrite != 0) ;
                    delay_ms(100);
                    byte[] request;
                    commReadData(out request);
                    if (respond.Length != 0)
                    {
                        if (request.Length == 0 || request[0] != respond[0])
                        {
                            labelMessage.Text += "Error";
                            downloadFlag = false;
                        }
                    }
                }
                else if(fsm_downLoadStep == "fsm_downLoadAppComplete")
                {
                    return true;
                }
                progressBar.Value = (int)(100 * sectorIndex/(appArray.Length/ c_u32_mcuSize));
            }
            return false;
        }

        private void DownLoad_Click(object sender, EventArgs e)
        {
            bool flag;
            if(readyCmd.Length == 0)
            {
                labelMessage.Text = "Ready Cmd Error";
                return;
            }
            else if (boot.Length == 0)
            {
                labelMessage.Text = "Boot Cmd Error";
                return;
            }
            else if (appArray.Length == 0)
            {
                labelMessage.Text = "App File Not Open";
                return;
            }
            foreach (string com in SerialPort.GetPortNames())
            {
                if (SerialPortOpen(com, "115200"))
                {
                    flag = downloadStep();
                    SerialPortClose();
                    if(flag == true)
                    {
                        return;
                    }
                }
            }
        }

        private void settingForm(bool show)
        {
            SettingForm form = new SettingForm();
            ToolStripMenuItemSetting.Enabled = false;
            if (show)
            {
                form.ShowDialog();
            }
            else
            {
                form.Show();
            }
            readyCmd = form.readyCmd;
            boot = form.boot;
            form.Close();
            ToolStripMenuItemSetting.Enabled = true;
        }
        private void ToolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            settingForm(true);
        }
    }
}

namespace System
{
    /// <summary>
    /// 二进制数据 操作
    /// </summary>
    public class HexUtility
    {
        /// <summary>
        /// 二进制替换,假设没有替换则返回原数组对像的复本.
        /// </summary>
        /// <param name="sourceByteArray">源数据</param>
        /// <param name="oldValue">须要替换的数据</param>
        /// <param name="newValue">将要替换成为的数据</param>
        public static byte[] Replace(byte[] sourceByteArray, byte[] oldValue, byte[] newValue)
        {
            //创建新数据多出1字节
            int newArrayLen = (int)((newValue.Length / (double)oldValue.Length) * sourceByteArray.Length) + 1;
            //得到数组长度
            newArrayLen = Math.Max(newArrayLen, sourceByteArray.Length);
            //新的最后结果数组
            byte[] newByteArray = new byte[newArrayLen];
            //新数组的当前索引
            int curIndex = 0;
            //開始结束
            int start = -1;
            int end = -1;
            //当前查找到的索引
            int oldCurindex = 0;
            //替换数据替换
            for (int x = 0; x < sourceByteArray.Length; x++)
            {
                //查找要替换的数据
                if (sourceByteArray[x] == oldValue[oldCurindex])
                {
                    if (oldCurindex == 0)
                    {
                        start = x;
                    }
                    if (oldCurindex == oldValue.Length - 1)
                    {
                        end = x;
                        oldCurindex = 0;
                    }
                    else
                    {
                        oldCurindex++;
                    }
                }
                else
                {
                    oldCurindex = 0;
                    newByteArray[curIndex] = sourceByteArray[x];
                    curIndex++;
                }
                //数据查找完毕
                if (start != -1 && end != -1)
                {
                    //复制替换数据
                    Buffer.BlockCopy(newValue, 0, newByteArray, curIndex, newValue.Length);
                    //计算新数组的偏移量
                    curIndex += newValue.Length;
                    //又一次设置须要复制索引的索引
                    start = end = -1;
                }
            }

            //处理返回结果
            byte[] result = null;
            if (curIndex != 0)
            {
                result = new byte[curIndex];
                Buffer.BlockCopy(newByteArray, 0, result, 0, result.Length);
            }
            else
            {
                result = new byte[sourceByteArray.Length];
                Buffer.BlockCopy(sourceByteArray, 0, result, 0, result.Length);
            }
            return result;
        }

        /// <summary>
        /// 二进制替换,假设没有替换则返回原数组对像的复本.
        /// </summary>
        /// <param name="sourceByteArray">源数据</param>
        /// <param name="replaces">须要替换的数据集合</param>
        public static byte[] Replace(byte[] sourceByteArray, List<HexReplaceEntity> replaces)
        {


            //创建新数据多出1字节
            int newArrayLen = (int)((replaces.Sum(p => p.newValue.Length) / (double)replaces.Sum(p => p.oldValue.Length)) * sourceByteArray.Length) + 1;
            //得到数组长度
            newArrayLen = Math.Max(newArrayLen, sourceByteArray.Length);
            //新的最后结果数组
            byte[] newByteArray = new byte[newArrayLen];
            //新数组的当前索引
            int curIndex = 0;
            bool find = false;
            //替换数据替换
            for (int x = 0; x < sourceByteArray.Length; x++)
            {

                foreach (HexReplaceEntity rep in replaces)
                {
                    //查找要替换的数据
                    if (sourceByteArray[x] == rep.oldValue[rep.oldCurindex])
                    {
                        if (rep.oldCurindex == 0)
                        {
                            rep.start = x;
                        }
                        if (rep.oldCurindex == rep.oldValue.Length - 1)
                        {
                            rep.end = x;
                            rep.oldCurindex = 0;
                        }
                        else
                        {
                            rep.oldCurindex++;
                        }
                    }
                    else
                    {
                        rep.oldCurindex = 0;
                        newByteArray[curIndex] = sourceByteArray[x];
                        find = false;
                    }
                    //数据查找完毕
                    if (rep.start != -1 && rep.end != -1)
                    {
                        find = true;
                        if (rep.newValue.Length >= rep.oldValue.Length)
                        {
                            //复制替换数据
                            Buffer.BlockCopy(rep.newValue, 0, newByteArray, curIndex, rep.newValue.Length);
                            //计算新数组的偏移量
                            curIndex += rep.newValue.Length;
                        }
                        else
                        //由大字节替换为少字节时出现了问题
                        {
                            curIndex -= rep.end - rep.start;
                            //复制替换数据
                            Buffer.BlockCopy(rep.newValue, 0, newByteArray, curIndex, rep.newValue.Length);
                            //计算新数组的偏移量
                            curIndex += rep.newValue.Length;
                        }
                        //又一次设置须要复制索引的索引
                        rep.start = rep.end = -1;
                        break;
                    }
                }
                if (!find)
                {
                    curIndex++;
                }
            }

            //处理返回结果
            byte[] result = null;
            if (curIndex != 0)
            {
                result = new byte[curIndex];
                Buffer.BlockCopy(newByteArray, 0, result, 0, result.Length);
            }
            else
            {
                result = new byte[sourceByteArray.Length];
                Buffer.BlockCopy(sourceByteArray, 0, result, 0, result.Length);
            }
            return result;
        }
    }
    /// <summary>
    /// 替换数据实体
    /// </summary>
    public class HexReplaceEntity
    {
        /// <summary>
        /// 须要替换的原始值
        /// </summary>
        public byte[] oldValue { get; set; }

        /// <summary>
        /// 新值
        /// </summary>
        public byte[] newValue { get; set; }

        /// <summary>
        /// 默认開始结束标记
        /// </summary>
        internal int start = -1;
        /// <summary>
        /// 默认開始结束标记
        /// </summary>
        internal int end = -1;

        //当前查找到的索引
        internal int oldCurindex = 0;

    }
}
