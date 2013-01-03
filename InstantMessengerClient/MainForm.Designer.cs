namespace InstantMessenger
{
    partial class MainForm
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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.status = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.registerButton = new System.Windows.Forms.ToolStripMenuItem();
			this.loginButton = new System.Windows.Forms.ToolStripMenuItem();
			this.logoutButton = new System.Windows.Forms.ToolStripMenuItem();
			this.sendTo = new System.Windows.Forms.TextBox();
			this.talkButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
			this.statusStrip.Location = new System.Drawing.Point(0, 57);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(434, 30);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// status
			// 
			this.status.Name = "status";
			this.status.Size = new System.Drawing.Size(151, 25);
			this.status.Text = "Login or register";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerButton,
            this.loginButton,
            this.logoutButton,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(434, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// registerButton
			// 
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(61, 20);
			this.registerButton.Text = "Register";
			this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
			// 
			// loginButton
			// 
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(49, 20);
			this.loginButton.Text = "Login";
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// logoutButton
			// 
			this.logoutButton.Enabled = false;
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(57, 20);
			this.logoutButton.Text = "Logout";
			this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
			// 
			// sendTo
			// 
			this.sendTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.sendTo.Location = new System.Drawing.Point(256, 25);
			this.sendTo.Name = "sendTo";
			this.sendTo.Size = new System.Drawing.Size(85, 20);
			this.sendTo.TabIndex = 2;
			this.sendTo.Visible = false;
			// 
			// talkButton
			// 
			this.talkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.talkButton.Enabled = false;
			this.talkButton.Location = new System.Drawing.Point(347, 27);
			this.talkButton.Name = "talkButton";
			this.talkButton.Size = new System.Drawing.Size(75, 23);
			this.talkButton.TabIndex = 3;
			this.talkButton.Text = "Talk";
			this.talkButton.UseVisualStyleBackColor = true;
			this.talkButton.Click += new System.EventHandler(this.talkButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Username:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(67, 25);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(183, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 87);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.talkButton);
			this.Controls.Add(this.sendTo);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip1);
			this.Name = "MainForm";
			this.Text = "My Instant Messenger";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registerButton;
        private System.Windows.Forms.ToolStripMenuItem loginButton;
        private System.Windows.Forms.ToolStripMenuItem logoutButton;
        private System.Windows.Forms.TextBox sendTo;
        private System.Windows.Forms.Button talkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;


    }
}

