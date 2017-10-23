using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace src.QR_GEN
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.textbox = new System.Windows.Forms.TextBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.generatebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.openbtn = new System.Windows.Forms.Button();
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.append = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menustrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savefile = new System.Windows.Forms.SaveFileDialog();
            this.passwdcheck = new System.Windows.Forms.CheckBox();
            this.printbtn = new System.Windows.Forms.Button();
            this.qrhide = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.menustrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textbox.Location = new System.Drawing.Point(13, 381);
            this.textbox.Name = "textbox";
            this.textbox.PasswordChar = '*';
            this.textbox.Size = new System.Drawing.Size(389, 20);
            this.textbox.TabIndex = 0;
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picture.Location = new System.Drawing.Point(12, 12);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(389, 350);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // generatebtn
            // 
            this.generatebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generatebtn.Location = new System.Drawing.Point(326, 439);
            this.generatebtn.Name = "generatebtn";
            this.generatebtn.Size = new System.Drawing.Size(75, 23);
            this.generatebtn.TabIndex = 2;
            this.generatebtn.Text = "generate";
            this.generatebtn.UseVisualStyleBackColor = true;
            this.generatebtn.Click += new System.EventHandler(this.generatebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.Location = new System.Drawing.Point(245, 439);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // openbtn
            // 
            this.openbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openbtn.Location = new System.Drawing.Point(164, 439);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(75, 23);
            this.openbtn.TabIndex = 4;
            this.openbtn.Text = "open";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.openbtn_Click_1);
            // 
            // dialog
            // 
            this.dialog.FileName = "openFileDialog";
            this.dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.dialog_FileOk);
            // 
            // append
            // 
            this.append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.append.AutoSize = true;
            this.append.Location = new System.Drawing.Point(12, 409);
            this.append.Name = "append";
            this.append.Size = new System.Drawing.Size(88, 17);
            this.append.TabIndex = 4;
            this.append.Text = "append save";
            this.append.UseVisualStyleBackColor = true;
            this.append.CheckedChanged += new System.EventHandler(this.append_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.menustrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "QR Code Creator";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menustrip
            // 
            this.menustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menustrip.Name = "menustrip";
            this.menustrip.Size = new System.Drawing.Size(102, 26);
            this.menustrip.Opening += new System.ComponentModel.CancelEventHandler(this.menustrip_Opening);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.closeToolStripMenuItem.Text = "close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // savefile
            // 
            this.savefile.FileOk += new System.ComponentModel.CancelEventHandler(this.savefile_FileOk);
            // 
            // passwdcheck
            // 
            this.passwdcheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.passwdcheck.AutoSize = true;
            this.passwdcheck.Checked = true;
            this.passwdcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.passwdcheck.Location = new System.Drawing.Point(12, 432);
            this.passwdcheck.Name = "passwdcheck";
            this.passwdcheck.Size = new System.Drawing.Size(81, 17);
            this.passwdcheck.TabIndex = 5;
            this.passwdcheck.Text = "is password";
            this.passwdcheck.UseVisualStyleBackColor = true;
            this.passwdcheck.CheckedChanged += new System.EventHandler(this.passwdcheck_CheckedChanged);
            // 
            // printbtn
            // 
            this.printbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printbtn.BackColor = System.Drawing.SystemColors.Control;
            this.printbtn.Location = new System.Drawing.Point(315, 21);
            this.printbtn.Name = "printbtn";
            this.printbtn.Size = new System.Drawing.Size(75, 23);
            this.printbtn.TabIndex = 6;
            this.printbtn.Text = "Print";
            this.printbtn.UseVisualStyleBackColor = false;
            this.printbtn.Click += new System.EventHandler(this.printbtn_Click);
            // 
            // qrhide
            // 
            this.qrhide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.qrhide.AutoSize = true;
            this.qrhide.Location = new System.Drawing.Point(12, 453);
            this.qrhide.Name = "qrhide";
            this.qrhide.Size = new System.Drawing.Size(65, 17);
            this.qrhide.TabIndex = 7;
            this.qrhide.Text = "hide QR";
            this.qrhide.UseVisualStyleBackColor = true;
            this.qrhide.CheckedChanged += new System.EventHandler(this.qrhide_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(234, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "260*260",
            "130*130"});
            this.comboBox1.Location = new System.Drawing.Point(76, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(70, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "260*260";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "print size:";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.qrhide);
            this.Controls.Add(this.printbtn);
            this.Controls.Add(this.passwdcheck);
            this.Controls.Add(this.openbtn);
            this.Controls.Add(this.append);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.generatebtn);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.textbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(430, 484);
            this.Name = "Window";
            this.Text = "QR Code Creator v14.0.25420.1";
            this.Load += new System.EventHandler(this.Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.menustrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public System.Windows.Forms.TextBox textbox;
        public System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button generatebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button openbtn;
        private System.Windows.Forms.OpenFileDialog dialog;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip menustrip;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog savefile;
        private CheckBox passwdcheck;
        private Button printbtn;
        public CheckBox append;
        public CheckBox qrhide;
        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
    }
}

