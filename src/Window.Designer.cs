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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.generatebtn = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.append = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textbox.Location = new System.Drawing.Point(12, 278);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(260, 87);
            this.textbox.TabIndex = 0;
            this.textbox.Text = "";
            this.textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picture.Location = new System.Drawing.Point(12, 12);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(260, 260);
            this.picture.TabIndex = 1;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // generatebtn
            // 
            this.generatebtn.Location = new System.Drawing.Point(197, 371);
            this.generatebtn.Name = "generatebtn";
            this.generatebtn.Size = new System.Drawing.Size(75, 23);
            this.generatebtn.TabIndex = 2;
            this.generatebtn.Text = "generate";
            this.generatebtn.UseVisualStyleBackColor = true;
            this.generatebtn.Click += new System.EventHandler(this.generatebtn_Click);
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(116, 371);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 3;
            this.savebtn.Text = "save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // append
            // 
            this.append.AutoSize = true;
            this.append.Location = new System.Drawing.Point(12, 376);
            this.append.Name = "append";
            this.append.Size = new System.Drawing.Size(88, 17);
            this.append.TabIndex = 4;
            this.append.Text = "append save";
            this.append.UseVisualStyleBackColor = true;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 404);
            this.Controls.Add(this.append);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.generatebtn);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.Text = "QR Code Creator V1.1";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox textbox;
        public System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button generatebtn;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.CheckBox append;
    }
}

