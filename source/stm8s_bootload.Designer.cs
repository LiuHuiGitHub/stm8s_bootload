namespace UserSerialPort
{
    partial class stm8s_bootload
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stm8s_bootload));
            this.comboPortNum = new System.Windows.Forms.ComboBox();
            this.groupBoxCommSetting = new System.Windows.Forms.GroupBox();
            this.labelBsp = new System.Windows.Forms.Label();
            this.labelCom = new System.Windows.Forms.Label();
            this.comboBoxBps = new System.Windows.Forms.ComboBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpenBoot = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpenApp = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDownLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageBoot = new System.Windows.Forms.TabPage();
            this.textBoxBoot = new System.Windows.Forms.TextBox();
            this.tabPageApp = new System.Windows.Forms.TabPage();
            this.textBoxApp = new System.Windows.Forms.TextBox();
            this.tabPageMessage = new System.Windows.Forms.TabPage();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.groupBoxCommSetting.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageBoot.SuspendLayout();
            this.tabPageApp.SuspendLayout();
            this.tabPageMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboPortNum
            // 
            this.comboPortNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboPortNum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboPortNum.FormattingEnabled = true;
            this.comboPortNum.Location = new System.Drawing.Point(48, 20);
            this.comboPortNum.Name = "comboPortNum";
            this.comboPortNum.Size = new System.Drawing.Size(70, 20);
            this.comboPortNum.TabIndex = 0;
            this.comboPortNum.Click += new System.EventHandler(this.comboPortNum_Click);
            // 
            // groupBoxCommSetting
            // 
            this.groupBoxCommSetting.Controls.Add(this.labelBsp);
            this.groupBoxCommSetting.Controls.Add(this.labelCom);
            this.groupBoxCommSetting.Controls.Add(this.comboBoxBps);
            this.groupBoxCommSetting.Controls.Add(this.comboPortNum);
            this.groupBoxCommSetting.Location = new System.Drawing.Point(10, 28);
            this.groupBoxCommSetting.Name = "groupBoxCommSetting";
            this.groupBoxCommSetting.Size = new System.Drawing.Size(303, 54);
            this.groupBoxCommSetting.TabIndex = 8;
            this.groupBoxCommSetting.TabStop = false;
            this.groupBoxCommSetting.Text = "Setting";
            // 
            // labelBsp
            // 
            this.labelBsp.AutoSize = true;
            this.labelBsp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBsp.Location = new System.Drawing.Point(132, 23);
            this.labelBsp.Name = "labelBsp";
            this.labelBsp.Size = new System.Drawing.Size(29, 12);
            this.labelBsp.TabIndex = 15;
            this.labelBsp.Text = "BSP:";
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCom.Location = new System.Drawing.Point(14, 23);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(29, 12);
            this.labelCom.TabIndex = 13;
            this.labelCom.Text = "COM:";
            // 
            // comboBoxBps
            // 
            this.comboBoxBps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBps.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxBps.FormattingEnabled = true;
            this.comboBoxBps.Location = new System.Drawing.Point(169, 20);
            this.comboBoxBps.Name = "comboBoxBps";
            this.comboBoxBps.Size = new System.Drawing.Size(70, 20);
            this.comboBoxBps.TabIndex = 14;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemDownLoad,
            this.ToolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(324, 25);
            this.menuStrip.TabIndex = 28;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpenBoot,
            this.ToolStripMenuItemOpenApp});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(39, 21);
            this.ToolStripMenuItemFile.Text = "File";
            // 
            // ToolStripMenuItemOpenBoot
            // 
            this.ToolStripMenuItemOpenBoot.Name = "ToolStripMenuItemOpenBoot";
            this.ToolStripMenuItemOpenBoot.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemOpenBoot.Text = "OpenBoot";
            this.ToolStripMenuItemOpenBoot.Click += new System.EventHandler(this.openBootFile_Click);
            // 
            // ToolStripMenuItemOpenApp
            // 
            this.ToolStripMenuItemOpenApp.Name = "ToolStripMenuItemOpenApp";
            this.ToolStripMenuItemOpenApp.Size = new System.Drawing.Size(136, 22);
            this.ToolStripMenuItemOpenApp.Text = "OpenApp";
            this.ToolStripMenuItemOpenApp.Click += new System.EventHandler(this.openHexFile_Click);
            // 
            // ToolStripMenuItemDownLoad
            // 
            this.ToolStripMenuItemDownLoad.Name = "ToolStripMenuItemDownLoad";
            this.ToolStripMenuItemDownLoad.Size = new System.Drawing.Size(79, 21);
            this.ToolStripMenuItemDownLoad.Text = "Download";
            this.ToolStripMenuItemDownLoad.Click += new System.EventHandler(this.DownLoad_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(47, 21);
            this.ToolStripMenuItemHelp.Text = "Help";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabPageBoot);
            this.tabControl.Controls.Add(this.tabPageApp);
            this.tabControl.Controls.Add(this.tabPageMessage);
            this.tabControl.Location = new System.Drawing.Point(10, 88);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(307, 438);
            this.tabControl.TabIndex = 29;
            // 
            // tabPageBoot
            // 
            this.tabPageBoot.Controls.Add(this.textBoxBoot);
            this.tabPageBoot.Location = new System.Drawing.Point(4, 22);
            this.tabPageBoot.Name = "tabPageBoot";
            this.tabPageBoot.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBoot.Size = new System.Drawing.Size(299, 412);
            this.tabPageBoot.TabIndex = 0;
            this.tabPageBoot.Text = "Boot";
            this.tabPageBoot.UseVisualStyleBackColor = true;
            // 
            // textBoxBoot
            // 
            this.textBoxBoot.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBoot.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBoot.Location = new System.Drawing.Point(0, 0);
            this.textBoxBoot.Multiline = true;
            this.textBoxBoot.Name = "textBoxBoot";
            this.textBoxBoot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBoot.Size = new System.Drawing.Size(303, 416);
            this.textBoxBoot.TabIndex = 0;
            // 
            // tabPageApp
            // 
            this.tabPageApp.Controls.Add(this.textBoxApp);
            this.tabPageApp.Location = new System.Drawing.Point(4, 22);
            this.tabPageApp.Name = "tabPageApp";
            this.tabPageApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageApp.Size = new System.Drawing.Size(299, 412);
            this.tabPageApp.TabIndex = 1;
            this.tabPageApp.Text = "App";
            this.tabPageApp.UseVisualStyleBackColor = true;
            // 
            // textBoxApp
            // 
            this.textBoxApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxApp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxApp.Location = new System.Drawing.Point(0, 0);
            this.textBoxApp.Multiline = true;
            this.textBoxApp.Name = "textBoxApp";
            this.textBoxApp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxApp.Size = new System.Drawing.Size(303, 416);
            this.textBoxApp.TabIndex = 1;
            // 
            // tabPageMessage
            // 
            this.tabPageMessage.Controls.Add(this.textBoxMessage);
            this.tabPageMessage.Location = new System.Drawing.Point(4, 22);
            this.tabPageMessage.Name = "tabPageMessage";
            this.tabPageMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMessage.Size = new System.Drawing.Size(299, 412);
            this.tabPageMessage.TabIndex = 2;
            this.tabPageMessage.Text = "Message";
            this.tabPageMessage.UseVisualStyleBackColor = true;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMessage.Size = new System.Drawing.Size(303, 416);
            this.textBoxMessage.TabIndex = 1;
            // 
            // stm8s_bootload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 531);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBoxCommSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "stm8s_bootload";
            this.groupBoxCommSetting.ResumeLayout(false);
            this.groupBoxCommSetting.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageBoot.ResumeLayout(false);
            this.tabPageBoot.PerformLayout();
            this.tabPageApp.ResumeLayout(false);
            this.tabPageApp.PerformLayout();
            this.tabPageMessage.ResumeLayout(false);
            this.tabPageMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPortNum;
        private System.Windows.Forms.GroupBox groupBoxCommSetting;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDownLoad;
        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.Label labelBsp;
        private System.Windows.Forms.ComboBox comboBoxBps;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpenApp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOpenBoot;
        private System.Windows.Forms.TextBox textBoxBoot;
        private System.Windows.Forms.TextBox textBoxApp;
        private System.Windows.Forms.TabPage tabPageMessage;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TabPage tabPageApp;
        private System.Windows.Forms.TabPage tabPageBoot;
        private System.Windows.Forms.TabControl tabControl;
    }
}

