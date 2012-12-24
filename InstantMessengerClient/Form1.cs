using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SharedClasses;
using System.Threading;

namespace InstantMessenger
{
	public partial class Form1 : Form
	{
		IMClient im = new IMClient();

		public Form1()
		{
			InitializeComponent();

			// InstantMessenger Events
			//im.LoginOK += new EventHandler(im_LoginOK);
			//im.RegisterOK += new EventHandler(im_RegisterOK);
			//im.LoginFailed += new IMErrorEventHandler(im_LoginFailed);
			//im.RegisterFailed += new IMErrorEventHandler(im_RegisterFailed);
			//im.Disconnected += new EventHandler(im_Disconnected);
		}

		private string computerGuid;
		private List<string> currentLoggedInUsers;
		private void Form1_Load(object sender, EventArgs e)
		{
			im.RegisterOK += delegate
			{
				Login();
			};
			im.RegisterFailed += (sn, ev) =>
			{
				if (ev.Error != IMError.Exists)//Error is not already registered
					MessageBox.Show("Could not register: " + ev.Error.ToString());
				//im.Disconnected will handle to log in if the computer is already registered
			};

			im.LoginOK += delegate
			{
				status.Text = "Logged in, waiting for push messages...";
				im.SendAskServer(InstantMessengerShared.IM_GetLoggedInUsers);
			};
			im.LoginFailed += (sn, ev) =>
			{
				MessageBox.Show("Could not login: " + ev.Error.ToString());
			};

			im.Disconnected += delegate
			{
				status.Text = "Disconnected";
				foreach (TalkForm tf in talks)
					tf.Close();
				Login();
			};

			im.MessageReceived += (sn, ev) =>
			{
				if (ev.From == InstantMessengerShared.IM_ServerUsername)
				{
					if (ev.Message != null && ev.Message.Contains('|'))
					{
						string messageType = ev.Message.Split('|')[0];
						if (messageType.Equals(InstantMessengerShared.IM_GetLoggedInUsers.ToString(), StringComparison.InvariantCultureIgnoreCase))
						{
							if (currentLoggedInUsers != null)
							{
								currentLoggedInUsers.Clear();
								currentLoggedInUsers = null;
							}

							string pipeSplittetUsernames = ev.Message.Substring(InstantMessengerShared.IM_GetLoggedInUsers.ToString().Length + 1);//+1 to get rid of pipe
							string currentPcGuid = SettingsInterop.GetComputerGuidAsString();
							currentLoggedInUsers = pipeSplittetUsernames.Split('|').ToList();
							currentLoggedInUsers.RemoveAll(un => un.Equals(currentPcGuid, StringComparison.InvariantCultureIgnoreCase));
							if (currentLoggedInUsers.Count == 0)
								UserMessages.ShowWarningMessage("No other users online");
							else
							{
								this.BeginInvoke(new MethodInvoker(delegate
								{
									comboBox1.Items.Clear();
									foreach (string username in currentLoggedInUsers)
										comboBox1.Items.Add(username);
									status.Text = "New users added to list";
								}));
								//UserMessages.ShowInfoMessage(
								//    "You are" + Environment.NewLine
								//    + currentPcGuid + Environment.NewLine
								//    + "Other users" + Environment.NewLine
								//    + string.Join(Environment.NewLine, splitted));
							}
						}
					}
					//bw.Write(
					//    InstantMessengerShared.IM_GetLoggedInUsers
					//    + "|"
					//    + string.Join("|", prog.users));
					//bw.Flush();

				}
			};

			Register();
		}

		private void Register()
		{
			if (im.IsBusyConnecting())
			{
				ThreadingInterop.ActionAfterDelay(Register,
					TimeSpan.FromSeconds(1), err => UserMessages.ShowErrorMessage(err));
				return;
			}
			//Make sure user registered with username&password = computerGuid
			computerGuid = SettingsInterop.GetComputerGuidAsString();
			im.Register(computerGuid, computerGuid);
		}

		private void Login()
		{
			if (im.IsBusyConnecting())
			{
				ThreadingInterop.ActionAfterDelay(Login,
					TimeSpan.FromSeconds(1), err => UserMessages.ShowErrorMessage(err));
				return;
			}
			im.Login(computerGuid, computerGuid);
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			LogRegForm info = new LogRegForm();
			if (info.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				im.Register(info.UserName, info.Password);
				status.Text = "Registering...";
			}
		}
		private void loginButton_Click(object sender, EventArgs e)
		{
			LogRegForm info = new LogRegForm();
			if (info.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				im.Login(info.UserName, info.Password);
				status.Text = "Login...";
			}
		}

		//void im_LoginOK(object sender, EventArgs e)
		//{
		//    this.BeginInvoke(new MethodInvoker(delegate
		//    {
		//        status.Text = "Logged in!";
		//        registerButton.Enabled = false;
		//        loginButton.Enabled = false;
		//        logoutButton.Enabled = true;
		//        talkButton.Enabled = true;
		//    }));
		//}
		//void im_RegisterOK(object sender, EventArgs e)
		//{
		//    this.BeginInvoke(new MethodInvoker(delegate
		//    {
		//        status.Text = "Registered!";
		//        registerButton.Enabled = false;
		//        loginButton.Enabled = false;
		//        logoutButton.Enabled = true;
		//        talkButton.Enabled = true;
		//    }));
		//}
		//void im_LoginFailed(object sender, IMErrorEventArgs e)
		//{
		//    this.BeginInvoke(new MethodInvoker(delegate
		//    {
		//        status.Text = "Login failed!";
		//    }));
		//}
		//void im_RegisterFailed(object sender, IMErrorEventArgs e)
		//{
		//    this.BeginInvoke(new MethodInvoker(delegate
		//    {
		//        status.Text = "Register failed!";
		//    }));
		//}
		//void im_Disconnected(object sender, EventArgs e)
		//{
		//    this.BeginInvoke(new MethodInvoker(delegate
		//    {
		//        status.Text = "Disconnected!";
		//        registerButton.Enabled = true;
		//        loginButton.Enabled = true;
		//        logoutButton.Enabled = false;
		//        talkButton.Enabled = false;

		//        foreach (TalkForm tf in talks)
		//            tf.Close();
		//    }));
		//}

		private void logoutButton_Click(object sender, EventArgs e)
		{
			im.Disconnect();
		}

		List<TalkForm> talks = new List<TalkForm>();
		private void talkButton_Click(object sender, EventArgs e)
		{
			//TalkForm tf = new TalkForm(im, sendTo.Text);
			//sendTo.Text = "";
			if (comboBox1.SelectedIndex == -1)
			{
				UserMessages.ShowWarningMessage("Please select username first (if none are available, none are online)");
				return;
			}
			TalkForm tf = new TalkForm(im, comboBox1.SelectedItem.ToString());
			talks.Add(tf);
			tf.Show();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			im.Disconnect();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			talkButton.Enabled = comboBox1.SelectedIndex != -1;
		}
	}
}
