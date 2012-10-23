using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedClasses;

namespace InstantMessenger
{
    public enum IMError : byte
    {
		TooUserName = InstantMessengerShared.IM_TooUsername,
		TooPassword = InstantMessengerShared.IM_TooPassword,
		Exists = InstantMessengerShared.IM_Exists,
		NoExists = InstantMessengerShared.IM_NoExists,
		WrongPassword = InstantMessengerShared.IM_WrongPass
    }

    public class IMErrorEventArgs : EventArgs
    {
        IMError err;

        public IMErrorEventArgs(IMError error)
        {
            this.err = error;
        }

        public IMError Error
        {
            get { return err; }
        }
    }
    public class IMAvailEventArgs : EventArgs
    {
        string user;
        bool avail;

        public IMAvailEventArgs(string user, bool avail)
        {
            this.user = user;
            this.avail = avail;
        }

        public string UserName
        {
            get { return user; }
        }
        public bool IsAvailable
        {
            get { return avail; }
        }
    }
    public class IMReceivedEventArgs : EventArgs
    {
        string user;
        string msg;

        public IMReceivedEventArgs(string user, string msg)
        {
            this.user = user;
            this.msg = msg;
        }

        public string From
        {
            get { return user; }
        }
        public string Message
        {
            get { return msg; }
        }
    }

    public delegate void IMErrorEventHandler(object sender, IMErrorEventArgs e);
    public delegate void IMAvailEventHandler(object sender, IMAvailEventArgs e);
    public delegate void IMReceivedEventHandler(object sender, IMReceivedEventArgs e);
}
