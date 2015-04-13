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
    public partial class Users : Form, Presenter.InterfaceViews.IUsers
    {
        Dashboard dashboard;
        UsersPresenter presenter;
        EditUser editUser;

        public Users()
        {
            InitializeComponent();
        }

        public Users(Dashboard dashboard)
        {
            this.dashboard = dashboard;
            InitializeComponent();
            presenter = new Presenter.UsersPresenter(this);
        }

        public void fillUsers(List<MfinderContext.User> users)
        {
            usersBindingSource.DataSource = users;
            usersGridView.DataSource = usersBindingSource;

            //Hide all columns and make then read-only
            foreach (DataGridViewColumn column in usersGridView.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            showColumns();
            addAditionalButtonsToGrid();


            //remove last empty row
            usersGridView.AllowUserToAddRows = false;
        }

        public void addCellClickEvent()
        {
            usersGridView.CellContentClick += new DataGridViewCellEventHandler(usersGridView_CellContentClick);
        }

        private void showColumns()
        {
            usersGridView.Columns["firstname"].Visible = true;
            usersGridView.Columns["lastname"].Visible = true;
            usersGridView.Columns["username"].Visible = true;
            usersGridView.Columns["ramal"].Visible = true;
        }

        private void addAditionalButtonsToGrid()
        {
            DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
            EditColumn.Text = "Edit";
            EditColumn.Name = "Edit";
            EditColumn.DataPropertyName = "Edit";
            EditColumn.UseColumnTextForButtonValue = true;
            usersGridView.Columns.Add(EditColumn);
            DataGridViewButtonColumn DelColumn = new DataGridViewButtonColumn();
            DelColumn.Text = "Delete";
            DelColumn.Name = "Delete";
            DelColumn.DataPropertyName = "Delete";
            DelColumn.UseColumnTextForButtonValue = true;
            usersGridView.Columns.Add(DelColumn);
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

        private void backButton_Click(object sender, EventArgs e)
        {
            Hide();
            dashboard.Show();
        }

        private void usersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        e.RowIndex >= 1)
            {
                int idColumnIndex = senderGrid.Rows[0].Cells["Id"].ColumnIndex;
                int id = (int)senderGrid.Rows[e.RowIndex].Cells[idColumnIndex].Value;

                int firstnameColumnIndex = senderGrid.Rows[0].Cells["Firstname"].ColumnIndex;
                int lastnameColumnIndex = senderGrid.Rows[0].Cells["Lastname"].ColumnIndex;
                string firstname = senderGrid.Rows[e.RowIndex].Cells[firstnameColumnIndex].Value.ToString();
                string lastname = senderGrid.Rows[e.RowIndex].Cells[lastnameColumnIndex].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Edit"))
                {
                    //Handle for edit button

                    int ramalColumnIndex = senderGrid.Rows[0].Cells["Ramal"].ColumnIndex;
                    int dptoColumnIndex = senderGrid.Rows[0].Cells["RoleFk"].ColumnIndex;
                    int roleColumnIndex = senderGrid.Rows[0].Cells["DptoFk"].ColumnIndex;

                    string ramal = senderGrid.Rows[e.RowIndex].Cells[ramalColumnIndex].Value.ToString();
                    int dpto = (int)senderGrid.Rows[e.RowIndex].Cells[dptoColumnIndex].Value;
                    int role = (int)senderGrid.Rows[e.RowIndex].Cells[roleColumnIndex].Value;

                    MfinderContext.User user = new MfinderContext.User();
                    user.Firstname = firstname;
                    user.Lastname = lastname;
                    user.RoleFk = role;
                    user.DptoFk = dpto;
                    user.Ramal = ramal;
                    user.Id = id;

                    editUser = new EditUser(this, user);
                    editUser.Show();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    //Handle for delete button
                    bool confirm = showMessage("Are you sure you want to delete user " + firstname + " " + lastname + "?");
                    if (confirm)
                    {
                        bool delete = presenter.deleteUser(id);
                        if (delete)
                        {
                            updateUsersList();
                        }
                        else
                        {
                            showMessage("User " + firstname + " " + lastname + " coudn't be deleted!");
                        }

                    }
                }

            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            editUser = new EditUser(this);
            editUser.Show();
        }

        internal void updateUsersList()
        {
            presenter.loadUsersData();
        }
    }
}
