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
    public partial class LogRegForm : Form
    {
        public LogRegForm()
        {
            InitializeComponent();
        }

        public string UserName;
        public string Password;

        private void okButton_Click(object sender, EventArgs e)
        {
            UserName = userText.Text;
            Password = passText.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
