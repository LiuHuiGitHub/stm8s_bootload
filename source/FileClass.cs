using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace UserSerialPort
{
    class FileClass
    {
        private string openFileName = string.Empty;
        private string strings = string.Empty;
        public bool openFileFlag = false;

        public string GetFileLongName()
        {
            return openFileName;
        }
        public string GetFileName()
        {
            return System.IO.Path.GetFileName(openFileName);
        }
        public string GetExtensionName()
        {
            return System.IO.Path.GetExtension(openFileName);
        }
        public bool openFile(string filter)
        {
            OpenFileDialog fp_openFile = new OpenFileDialog();
            StreamReader myStream;
            fp_openFile.Filter = filter;
            if (fp_openFile.ShowDialog() == DialogResult.OK)
            {
                openFileName = fp_openFile.FileName;
                myStream = new StreamReader(fp_openFile.FileName);
                strings = myStream.ReadToEnd();
                myStream.Close();
                openFileFlag = true;
                return true;
            }
            openFileFlag = false;
            return false;
        }

        public bool GetStringArray(out string[] str)
        {
            str = new string[0];
            if(openFileFlag)
            {
                str = strings.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetString(out string str)
        {
            str = string.Empty;
            if (openFileFlag)
            {
                str = strings;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetByteArray(out byte[] bytes)
        {
            bytes = new byte[0];
            try
            {
                if (openFileFlag)
                {
                    string str = strings;
                    str = str.Replace(" ", "");     //将原string中的空格删除
                    str = str.Replace("0x", "");
                    str = str.Replace("0X", "");
                    str = str.Replace(",", "");
                    str = str.Replace("\r\n", "");
                    if (str.Length % 2 != 0)
                    {
                        str += " ";
                    }
                    bytes = new byte[str.Length / 2];
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = Convert.ToByte(str.Substring(i * 2, 2), 16);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("请检查文件是否正确！"
                        , "错误"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Warning);
                return false;
            }
        }
    }
}
