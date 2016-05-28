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
    public partial class MessageForm : Form
    {
        public string message
        {
            get
            {
                return this.textBoxMessage.Text;
            }
            set
            {
                this.textBoxMessage.Text = value;
            }
        }

        public MessageForm()
        {
            InitializeComponent();
        }
    }
}
