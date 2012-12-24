namespace InstantMessenger
{
    partial class TalkForm
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.talkText = new System.Windows.Forms.TextBox();
			this.sendText = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.sendButton = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.talkText);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.sendText);
			this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
			this.splitContainer1.Size = new System.Drawing.Size(584, 321);
			this.splitContainer1.SplitterDistance = 247;
			this.splitContainer1.TabIndex = 0;
			// 
			// talkText
			// 
			this.talkText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.talkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.talkText.Location = new System.Drawing.Point(0, 0);
			this.talkText.Multiline = true;
			this.talkText.Name = "talkText";
			this.talkText.ReadOnly = true;
			this.talkText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.talkText.Size = new System.Drawing.Size(580, 243);
			this.talkText.TabIndex = 2;
			// 
			// sendText
			// 
			this.sendText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sendText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.sendText.Location = new System.Drawing.Point(0, 0);
			this.sendText.Multiline = true;
			this.sendText.Name = "sendText";
			this.sendText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.sendText.Size = new System.Drawing.Size(580, 42);
			this.sendText.TabIndex = 1;
			this.sendText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sendText_KeyPress);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendButton});
			this.menuStrip1.Location = new System.Drawing.Point(0, 42);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(580, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// sendButton
			// 
			this.sendButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.sendButton.Name = "sendButton";
			this.sendButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.sendButton.Size = new System.Drawing.Size(94, 20);
			this.sendButton.Text = "Send message";
			this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
			// 
			// timer
			// 
			this.timer.Enabled = true;
			this.timer.Interval = 10000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// TalkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 321);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TalkForm";
			this.Text = "Talk";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TalkForm_FormClosing);
			this.Load += new System.EventHandler(this.TalkForm_Load);
			this.Shown += new System.EventHandler(this.TalkForm_Shown);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox sendText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendButton;
        private System.Windows.Forms.TextBox talkText;
        private System.Windows.Forms.Timer timer;
    }
}