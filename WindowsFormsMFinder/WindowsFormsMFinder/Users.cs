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
    public partial class Users : Form, Presenter.InterfaceViews.IManageUser
    {
        Dashboard dashboard;
        ManageUserPresenter presenter;

        public Users()
        {
            InitializeComponent();
        }

        public Users(Dashboard dashboard)
        {
            this.dashboard = dashboard;
            InitializeComponent();
            presenter = new Presenter.ManageUserPresenter(this);
        }

        public void fillUsers(List<MfinderContext.User> users)
        {
            usersBindingSource.DataSource = users;
            usersGridView.DataSource = usersBindingSource;

            //Make all rows as Read-only
            foreach (DataGridViewRow row in usersGridView.Rows)
            {
                row.ReadOnly = true;
            }

            //Hide all columns
            foreach (DataGridViewColumn column in usersGridView.Columns)
            {
                column.Visible = false;
            }

            //Show only some columns
            usersGridView.Columns["firstname"].Visible = true;
            usersGridView.Columns["lastname"].Visible = true;
            usersGridView.Columns["username"].Visible = true;
            usersGridView.Columns["ramal"].Visible = true;

            //Fazer a logica de habilitar o botao de editar e excluir aki
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
