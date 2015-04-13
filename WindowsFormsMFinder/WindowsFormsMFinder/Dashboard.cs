using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsMFinder
{
    public partial class Dashboard : Form, Presenter.InterfaceViews.IDashboard
    {
        private Login login;
        private DashboardPresenter presenter;
        private Users u;
        private Loans l;
        private Machines m;
        private History h;

        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(Login login)
        {
            presenter = new DashboardPresenter(this);
            u = new Users(this);
            l = new Loans(this);
            m = new Machines(this);
            h = new History(this);
            InitializeComponent();
            this.login = login;
        }

        private void manageUsersButton_Click(object sender, EventArgs e)
        {
            Hide();
            u.Show();
        }

        private void manageMachinesButton_Click(object sender, EventArgs e)
        {
            Hide();
            m.Show();
        }
    }
}
