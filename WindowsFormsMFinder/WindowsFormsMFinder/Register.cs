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
    public partial class Register : Form, IRegister
    {
        private Login login;
        Presenter.RegisterPresenter presenter;

        public Register()
        {
            InitializeComponent();
        }

        public Register(Login login)
        {
            this.login = login;
            presenter = new Presenter.RegisterPresenter(this);
            InitializeComponent();
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            presenter.view_registerEvent(sender, e);
        }

        public string username
        {
            get
            {
                return textBoxUsername.Text;
            }
        }

        public string password
        {
            get
            {
                return textBoxPassword.Text;
            }
        }


        public string repeatPw
        {
            get
            {
                return textBoxRepeatPW.Text;
            }
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


        public void goToLogin()
        {
            login.Show();
            Hide();
        }
    }
}
