namespace stm8s_bootload
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxReadyCmd = new System.Windows.Forms.TextBox();
            this.textBoxBoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxReadyCmd
            // 
            this.textBoxReadyCmd.Location = new System.Drawing.Point(12, 31);
            this.textBoxReadyCmd.Name = "textBoxReadyCmd";
            this.textBoxReadyCmd.Size = new System.Drawing.Size(507, 21);
            this.textBoxReadyCmd.TabIndex = 0;
            // 
            // textBoxBoot
            // 
            this.textBoxBoot.Location = new System.Drawing.Point(12, 83);
            this.textBoxBoot.Multiline = true;
            this.textBoxBoot.Name = "textBoxBoot";
            this.textBoxBoot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBoot.Size = new System.Drawing.Size(507, 166);
            this.textBoxBoot.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "就绪命令:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Boot命令:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxBoot);
            this.Controls.Add(this.textBoxReadyCmd);
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.helpForm_Closed);
            this.Load += new System.EventHandler(this.helpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReadyCmd;
        private System.Windows.Forms.TextBox textBoxBoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}