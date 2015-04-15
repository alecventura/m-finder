using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsMFinder
{
    public partial class Machines : Form, Presenter.InterfaceViews.IMachines
    {
        private Dashboard dashboard;
        private Presenter.MachinesPresenter presenter;
        private EditMachine editMachine;

        public Machines()
        {
            InitializeComponent();
        }

        public Machines(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            presenter = new Presenter.MachinesPresenter(this);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            editMachine = new EditMachine(this);
            editMachine.Show();
        }

        public void fillMachines(List<MfinderContext.Machine> machines)
        {
            machinesBindingSource.DataSource = machines;
            machinesGridView.DataSource = machinesBindingSource;

            //Hide all columns and make then read-only
            foreach (DataGridViewColumn column in machinesGridView.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            showColumns();
            addAditionalButtonsToGrid();


            //remove last empty row
            machinesGridView.AllowUserToAddRows = false;
        }

        private void showColumns()
        {
            machinesGridView.Columns["name"].Visible = true;
            machinesGridView.Columns["model"].Visible = true;
            machinesGridView.Columns["serialnumber"].Visible = true;
            machinesGridView.Columns["aquisitionDate"].Visible = true;
            machinesGridView.Columns["warrantyExpirationDate"].Visible = true;
        }

        private void addAditionalButtonsToGrid()
        {
            DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
            EditColumn.Text = "Edit";
            EditColumn.Name = "Edit";
            EditColumn.DataPropertyName = "Edit";
            EditColumn.UseColumnTextForButtonValue = true;
            machinesGridView.Columns.Add(EditColumn);
            DataGridViewButtonColumn DelColumn = new DataGridViewButtonColumn();
            DelColumn.Text = "Delete";
            DelColumn.Name = "Delete";
            DelColumn.DataPropertyName = "Delete";
            DelColumn.UseColumnTextForButtonValue = true;
            machinesGridView.Columns.Add(DelColumn);
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


        public void addCellClickEvent()
        {
            machinesGridView.CellContentClick += new DataGridViewCellEventHandler(machinesGridView_CellContentClick);
        }

        private void machinesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        e.RowIndex >= 0)
            {
                int idColumnIndex = senderGrid.Rows[0].Cells["Id"].ColumnIndex;
                int id = (int)senderGrid.Rows[e.RowIndex].Cells[idColumnIndex].Value;

                int serialnumberColumnIndex = senderGrid.Rows[0].Cells["Serialnumber"].ColumnIndex;
                string serialNumber = senderGrid.Rows[e.RowIndex].Cells[serialnumberColumnIndex].Value.ToString();

                int nameColumnIndex = senderGrid.Rows[0].Cells["Name"].ColumnIndex;
                string name = senderGrid.Rows[e.RowIndex].Cells[nameColumnIndex].Value.ToString();
                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Edit"))
                {
                    int modelColumnIndex = senderGrid.Rows[0].Cells["Model"].ColumnIndex;
                    string model = senderGrid.Rows[e.RowIndex].Cells[modelColumnIndex].Value.ToString();
                    int aquisitionDateColumnIndex = senderGrid.Rows[0].Cells["AquisitionDate"].ColumnIndex;
                    DateTime aquisitionDate = DateTime.Parse(senderGrid.Rows[e.RowIndex].Cells[aquisitionDateColumnIndex].Value.ToString());
                    int warrantyExpirationDateColumnIndex = senderGrid.Rows[0].Cells["WarrantyExpirationDate"].ColumnIndex;
                    DateTime warrantyExpirationDate = DateTime.Parse(senderGrid.Rows[e.RowIndex].Cells[warrantyExpirationDateColumnIndex].Value.ToString());

                    MfinderContext.Machine m = new MfinderContext.Machine();
                    m.WarrantyExpirationDate = warrantyExpirationDate;
                    m.Name = name;
                    m.Serialnumber = serialNumber;
                    m.Model = model;
                    m.AquisitionDate = aquisitionDate;
                    m.Id = id;

                    editMachine = new EditMachine(this, m);
                    editMachine.Show();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Delete"))
                {
                    //Handle for delete button
                    bool confirm = showMessage("Are you sure you want to delete machine " + name + " with serialnumber " + serialNumber + "?");
                    if (confirm)
                    {
                        bool delete = presenter.deleteMachine(id);
                        if (delete)
                        {
                            presenter.loadMachines();
                        }
                        else
                        {
                            showMessage("Machine with serialnumber= " + serialNumber + " coudn't be deleted!");
                        }

                    }
                }

            }
        }

        internal void updateMachinesList()
        {
            presenter.loadMachines();
        }
    }
}
