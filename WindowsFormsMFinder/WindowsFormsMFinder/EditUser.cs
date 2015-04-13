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
    public partial class EditUser : Form, IEditUser
    {
        private Users users;
        private Presenter.EditUserPresenter presenter;
        private int id;

        public EditUser()
        {
            InitializeComponent();
        }

        public EditUser(Users users)
        {
            this.users = users;
            InitializeComponent();
            presenter = new Presenter.EditUserPresenter(this);
        }

        public EditUser(Users users, MfinderContext.User user)
        {
            this.users = users;
            InitializeComponent();

            this.textBoxFirstName.Text = user.Firstname;
            this.textBoxLastName.Text = user.Lastname;
            this.textBoxRamal.Text = user.Ramal;
            setRole(user.RoleFk);
            setDpto((int)user.DptoFk);
            this.id = user.Id;
            presenter = new Presenter.EditUserPresenter(this);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            presenter.saveUser(sender, e);
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

        public void fillDptoList(List<MfinderContext.Dpto> list)
        {
            bindingSourceDptos.DataSource = list;
            comboBoxDptos.DataSource = bindingSourceDptos;
            comboBoxDptos.ValueMember = "name";
        }

        public void fillRoleList(List<MfinderContext.Role> list)
        {
            bindingSourceRoles.DataSource = list;
            comboBoxRoles.DataSource = bindingSourceRoles;
            comboBoxRoles.ValueMember = "name";
        }

        string Presenter.InterfaceViews.IEditUser.firstname
        {
            get
            {
                return textBoxFirstName.Text;
            }
            set
            {
                textBoxFirstName.Text = value;
            }
        }

        string Presenter.InterfaceViews.IEditUser.lastname
        {
            get
            {
                return textBoxLastName.Text;
            }
            set
            {
                textBoxLastName.Text = value;
            }
        }

        string Presenter.InterfaceViews.IEditUser.ramal
        {
            get
            {
                return textBoxRamal.Text;
            }
            set
            {
                textBoxRamal.Text = value;
            }
        }

        int Presenter.InterfaceViews.IEditUser.dpto
        {
            get
            {
                MfinderContext.Dpto obj = (MfinderContext.Dpto)comboBoxDptos.SelectedItem;
                return obj.Id;
            }
            set
            {
                setDpto(value);
            }
        }

        private void setDpto(int value)
        {
            foreach (MfinderContext.Dpto dpto in comboBoxDptos.Items)
            {
                if (dpto.Id.Equals(value))
                {
                    comboBoxDptos.SelectedItem = dpto;
                }
            }
        }

        int Presenter.InterfaceViews.IEditUser.role
        {
            get
            {
                MfinderContext.Role obj = (MfinderContext.Role)comboBoxRoles.SelectedItem;
                return obj.Id;
            }
            set
            {
                setRole(value);
            }
        }

        private void setRole(int value)
        {
            foreach (MfinderContext.Role role in comboBoxRoles.Items)
            {
                if (role.Id.Equals(value))
                {
                    comboBoxRoles.SelectedItem = role;
                }
            }
        }

        int Presenter.InterfaceViews.IEditUser.id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }


        public void goToUsers()
        {
            users.updateUsersList();
            this.Hide();
            users.Show();
        }
    }
}
