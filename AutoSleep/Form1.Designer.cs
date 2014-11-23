namespace AutoSleep
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.SecsTbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fullscreenChk = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SecsTbox
            // 
            this.SecsTbox.Location = new System.Drawing.Point(35, 48);
            this.SecsTbox.Name = "SecsTbox";
            this.SecsTbox.Size = new System.Drawing.Size(100, 20);
            this.SecsTbox.TabIndex = 1;
            this.SecsTbox.Text = "60";
            this.SecsTbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Interval in minutes:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fullscreenChk);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // mynotifyicon
            // 
            this.mynotifyicon.Icon = ((System.Drawing.Icon)(resources.GetObject("mynotifyicon.Icon")));
            this.mynotifyicon.Text = "Auto Sleep";
            this.mynotifyicon.Visible = true;
            this.mynotifyicon.Click += new System.EventHandler(this.mynotifyicon_Click);
            this.mynotifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mynotifyicon_MouseDoubleClick);
            // 
            // fullscreenChk
            // 
            this.fullscreenChk.AutoSize = true;
            this.fullscreenChk.Checked = true;
            this.fullscreenChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullscreenChk.Location = new System.Drawing.Point(12, 99);
            this.fullscreenChk.Name = "fullscreenChk";
            this.fullscreenChk.Size = new System.Drawing.Size(117, 17);
            this.fullscreenChk.TabIndex = 0;
            this.fullscreenChk.Text = "Disable if fullscreen";
            this.fullscreenChk.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 151);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SecsTbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sleep";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SecsTbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon mynotifyicon;
        private System.Windows.Forms.CheckBox fullscreenChk;
    }
}

