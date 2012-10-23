using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstantMessenger
{
    public partial class TalkForm : Form
    {
        public TalkForm(IMClient im, string user)
        {
            InitializeComponent();
            this.im = im;
            this.sendTo = user;
        }

        public IMClient im;
        public string sendTo;

        IMAvailEventHandler availHandler;
        IMReceivedEventHandler receivedHandler;
        private void TalkForm_Load(object sender, EventArgs e)
        {
            this.Text = sendTo;
            availHandler = new IMAvailEventHandler(im_UserAvailable);
            receivedHandler = new IMReceivedEventHandler(im_MessageReceived);
            im.UserAvailable += availHandler;
            im.MessageReceived += receivedHandler;
            im.IsAvailable(sendTo);
        }
        private void TalkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            im.UserAvailable -= availHandler;
            im.MessageReceived -= receivedHandler;
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            im.SendMessage(sendTo, sendText.Text);
            talkText.Text += String.Format("[{0}] {1}\r\n", im.UserName, sendText.Text);
            sendText.Text = "";
        }

        bool lastAvail = false;
        void im_UserAvailable(object sender, IMAvailEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.UserName == sendTo)
                {
                    if (lastAvail != e.IsAvailable)
                    {
                        lastAvail = e.IsAvailable;
                        string avail = (e.IsAvailable ? "available" : "unavailable");
                        this.Text = String.Format("{0} - {1}", sendTo, avail);
                        talkText.Text += String.Format("[{0} is {1}]\r\n", sendTo, avail);
                    }
                }
            }));
        }
        void im_MessageReceived(object sender, IMReceivedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                if (e.From == sendTo)
                {
                    talkText.Text += String.Format("[{0}] {1}\r\n", e.From, e.Message);
                }
            }));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            im.IsAvailable(sendTo);
        }

		private void sendText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((int)e.KeyChar == 13
				&& !Control.ModifierKeys.HasFlag(Keys.Control)
				&& !Control.ModifierKeys.HasFlag(Keys.Shift))
			{
				e.Handled = true;
				sendButton.PerformClick();
			}
		}

		private void TalkForm_Shown(object sender, EventArgs e)
		{
			sendText.Focus();
		}
    }
}
