using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Presenter.InterfaceViews;

namespace WindowsFormsMFinder
{
    public partial class Login : Form, ILogin
    {
        Register r;
        Dashboard d;
        Presenter.LoginPresenter presenter;
        public Login()
        {
            presenter = new Presenter.LoginPresenter(this);
            r = new Register(this);
            d = new Dashboard(this);
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            r.Show();
            Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            presenter.view_loginEvent(sender, e);
        }

        public string username
        {
            get { return textBoxUsername.Text; }
        }

        public string password
        {
            get { return textBoxPassword.Text; }
        }


        public void openDashboard()
        {
            d.Show();
            Hide();
        }

        public bool showMessage(string message)
        {
            DialogResult result = MessageBox.Show(message);
            if (DialogResult.OK.Equals(result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
