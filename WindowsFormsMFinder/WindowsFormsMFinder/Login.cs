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
        Presenter.LoginPresenter presenter;
        public Login()
        {
            presenter = new Presenter.LoginPresenter(this);
            r = new Register(this);
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
    }
}
