using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using SharedClasses;

/*
 * Code obtained from:
 * http://www.codeproject.com/Articles/429144/Simple-Instant-Messenger-with-SSL-Encryption-in-Cs
 */

namespace InstantMessenger
{
	public class IMClient
	{
		Thread tcpThread;      // Receiver
		bool _conn = false;    // Is connected/connecting?
		bool _logged = false;  // Is logged in?
		string _user;          // Username
		string _pass;          // Password
		bool reg;              // Register mode

		public string Server
		{
			get
			{
				return
					//"10.0.0.220";
					//"chatserver.getmyip.com";
					// ".....m;;;;;;;;;;;;;;";
					//"fjh.dyndns.org";// Address of server. In this case - local IP address.
					"commandlistener.getmyip.com";
					//"10.0.0.105";
				//"192.168.1.167";
			}
		}
		public int Port
		{
			get
			{
				return
					//9002
					443
					//80
					;
			}
		}//80; } }//2000; } }

		public bool IsLoggedIn { get { return _logged; } }
		public string UserName { get { return _user; } }
		public string Password { get { return _pass; } }

		public bool IsBusyConnecting() { return _conn; }

		// Start connection thread and login or register.
		void connect(string user, string password, bool register)
		{
			if (!_conn)
			{
				_conn = true;
				_user = user;
				_pass = password;
				reg = register;
				tcpThread = new Thread(new ThreadStart(SetupConn));
				tcpThread.Start();
			}
		}
		public void Login(string user, string password)
		{
			connect(user, password, false);
		}
		public void Register(string user, string password)
		{
			connect(user, password, true);
		}
		public void Disconnect()
		{
			if (_conn)
				CloseConn();
		}

		public void IsAvailable(string user)
		{
			if (_conn)
			{
				bw.Write(InstantMessengerShared.IM_IsAvailable);
				bw.Write(user);
				bw.Flush();
			}
		}
		public void SendMessage(string to, string msg)
		{
			if (_conn)
			{
				bw.Write(InstantMessengerShared.IM_Send);
				bw.Write(to);
				bw.Write(msg);
				bw.Flush();
			}
		}
		public void SendAskServer(byte msg)
		{
			if (_conn)
			{
				//Copied code from SendMessage(..)
				bw.Write(InstantMessengerShared.IM_AskServer);
				bw.Write(msg);
				bw.Flush();
			}
		}

		// Events
		public event EventHandler LoginOK;
		public event EventHandler RegisterOK;
		public event IMErrorEventHandler LoginFailed;
		public event IMErrorEventHandler RegisterFailed;
		public event EventHandler Disconnected;
		public event IMAvailEventHandler UserAvailable;
		public event IMReceivedEventHandler MessageReceived;

		virtual protected void OnLoginOK()
		{
			if (LoginOK != null)
				LoginOK(this, EventArgs.Empty);
		}
		virtual protected void OnRegisterOK()
		{
			if (RegisterOK != null)
				RegisterOK(this, EventArgs.Empty);
		}
		virtual protected void OnLoginFailed(IMErrorEventArgs e)
		{
			if (LoginFailed != null)
				LoginFailed(this, e);
		}
		virtual protected void OnRegisterFailed(IMErrorEventArgs e)
		{
			if (RegisterFailed != null)
				RegisterFailed(this, e);
		}
		virtual protected void OnDisconnected()
		{
			if (Disconnected != null)
				Disconnected(this, EventArgs.Empty);
		}
		virtual protected void OnUserAvail(IMAvailEventArgs e)
		{
			if (UserAvailable != null)
				UserAvailable(this, e);
		}
		virtual protected void OnMessageReceived(IMReceivedEventArgs e)
		{
			if (MessageReceived != null)
				MessageReceived(this, e);
		}


		TcpClient client;
		NetworkStream netStream;
		SslStream ssl;
		BinaryReader br;
		BinaryWriter bw;

		void SetupConn()  // Setup connection and login
		{
			client = new TcpClient(Server, Port);  // Connect to the server.
			netStream = client.GetStream();
			ssl = new SslStream(netStream, false, new RemoteCertificateValidationCallback(ValidateCert));
			ssl.AuthenticateAsClient("InstantMessengerServer");
			// Now we have encrypted connection.

			//byte[] header = Encoding.UTF8.GetBytes(
			//    "GET / HTTP/1.1\r\nHost: " + Server + "\r\n"
			//    + "Connection: Keep-Alive" + "\r\n"
			//    + "\r\n");
			//ssl.Write(header, 0, header.Length);
			//ssl.Flush();

			br = new BinaryReader(ssl/*netStream*/, Encoding.UTF8);
			bw = new BinaryWriter(ssl/*netStream*/, Encoding.UTF8);

			// Receive "hello"
			try
			{
				//int readnum = 0;
				//byte[] buf = new byte[1];
				//string responseheader = "";
				//while ((readnum = ssl.Read(buf, 0, buf.Length)) > 0)
				//{
				//    responseheader += Encoding.UTF8.GetString(buf);
				//    if (responseheader.EndsWith("\r\n\r\n"))
				//        break;
				//}

				int hello = br.ReadInt32();
				if (hello == InstantMessengerShared.IM_Hello)
				{
					// Hello OK, so answer.
					bw.Write(InstantMessengerShared.IM_Hello);

					bw.Write(reg ? InstantMessengerShared.IM_Register : InstantMessengerShared.IM_Login);  // Login or register
					bw.Write(UserName);
					bw.Write(Password);
					bw.Flush();

					byte ans = br.ReadByte();  // Read answer.
					if (ans == InstantMessengerShared.IM_OK)  // Login/register OK
					{
						if (reg)
							OnRegisterOK();  // Register is OK.
						OnLoginOK();  // Login is OK (when registered, automatically logged in)
						Receiver(); // Time for listening for incoming messages.
					}
					else
					{
						IMErrorEventArgs err = new IMErrorEventArgs((IMError)ans);
						if (reg)
							OnRegisterFailed(err);
						else
							OnLoginFailed(err);
					}
				}
				if (_conn)
					CloseConn();
			}
			catch (Exception exc)
			{
				System.Windows.Forms.MessageBox.Show("Error: " + exc.Message);
			}
		}
		void CloseConn() // Close connection.
		{
			br.Close();
			bw.Close();
			ssl.Close();
			netStream.Close();
			client.Close();
			OnDisconnected();
			_conn = false;
		}
		void Receiver()  // Receive all incoming packets.
		{
			_logged = true;

			try
			{
				while (client.Connected)  // While we are connected.
				{
					byte type = br.ReadByte();  // Get incoming packet type.

					if (type == InstantMessengerShared.IM_IsAvailable)
					{
						string user = br.ReadString();
						bool isAvail = br.ReadBoolean();
						OnUserAvail(new IMAvailEventArgs(user, isAvail));
					}
					else if (type == InstantMessengerShared.IM_Received)
					{
						string from = br.ReadString();
						string msg = br.ReadString();
						OnMessageReceived(new IMReceivedEventArgs(from, msg));
					}
				}
			}
			catch (IOException) { }

			_logged = false;
		}

		public static bool ValidateCert(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			// Uncomment this lines to disallow untrusted certificates.
			//if (sslPolicyErrors == SslPolicyErrors.None)
			//    return true;
			//else
			//    return false;

			return true; // Allow untrusted certificates.
		}
	}
}
