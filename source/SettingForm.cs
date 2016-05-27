using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stm8s_bootload
{
    public partial class SettingForm : Form
    {
        private byte[] stringToHexArray(string strings)
        {
            byte[] bytes = { };
            try
            {
                strings = strings.Replace("\r\n", "");
                strings = strings.Replace(" ", "");
                strings = strings.Replace("0x", "");
                strings = strings.Replace("0X", "");
                strings = strings.Replace(",", "");
                if (strings.Length % 2 != 0)
                {
                    strings += " ";
                }
                bytes = new byte[strings.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(strings.Substring(i * 2, 2), 16);
                }
            }
            catch
            {
                bytes = new byte[] { };
            }
            return bytes;
        }
        public byte[] readyCmd
        {
            get { return stringToHexArray(this.textBoxReadyCmd.Text.ToString()); }
        }

        public byte[] boot
        {
            get
            {
                byte[] bytes = stringToHexArray(this.textBoxBoot.Text.ToString());
                if (bytes.Length > 2
                    && bytes[bytes.Length-2] == 0xAA
                    && bytes[bytes.Length - 1] == 0xCC
                    )
                {
                    return bytes;
                }
                else
                {
                    return new byte[] { };
                }
            }
        }

        public SettingForm()
        {
            InitializeComponent();
        }

        private void helpForm_Load(object sender, EventArgs e)
        {
            textBoxReadyCmd.Text = Settings.Default.readyCmd;
            textBoxBoot.Text = Settings.Default.boot;
        }

        private void helpForm_Closed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.readyCmd = textBoxReadyCmd.Text;
            Settings.Default.boot = textBoxBoot.Text;
            Settings.Default.Save();
        }
    }
}
