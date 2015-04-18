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
    public partial class Loans : Form, Presenter.InterfaceViews.ILoans
    {
        private Dashboard dashboard;
        private Presenter.LoansPresenter presenter;

        public Loans()
        {
            InitializeComponent();
        }

        public Loans(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.presenter = new Presenter.LoansPresenter(this);

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard.Show();
        }

        public void fillLoans(List<Model.DAOs.LoanDAO.Loan> loans)
        {
            bindingSourceLoans.DataSource = loans;
            loansGridView.DataSource = bindingSourceLoans;

            //Hide all columns and make then read-only
            foreach (DataGridViewColumn column in loansGridView.Columns)
            {
                column.Visible = false;
                column.ReadOnly = true;
            }

            showColumns();
            addAditionalButtonsToGrid();


            //remove last empty row
            loansGridView.AllowUserToAddRows = false;
        }

        private void showColumns()
        {
            // User data
            loansGridView.Columns["user.firstname"].Visible = true;
            loansGridView.Columns["lastname"].Visible = true;
            loansGridView.Columns["username"].Visible = true;
            loansGridView.Columns["ramal"].Visible = true;
            // Machine data
            loansGridView.Columns["name"].Visible = true;
            loansGridView.Columns["model"].Visible = true;
            loansGridView.Columns["serialnumber"].Visible = true;
            loansGridView.Columns["aquisitionDate"].Visible = true;
            loansGridView.Columns["warrantyExpirationDate"].Visible = true;
        }

        private void addAditionalButtonsToGrid()
        {
            //DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
            //EditColumn.Text = "Edit";
            //EditColumn.Name = "Edit";
            //EditColumn.DataPropertyName = "Edit";
            //EditColumn.UseColumnTextForButtonValue = true;
            //loansGridView.Columns.Add(EditColumn);
            //DataGridViewButtonColumn DelColumn = new DataGridViewButtonColumn();
            //DelColumn.Text = "Delete";
            //DelColumn.Name = "Delete";
            //DelColumn.DataPropertyName = "Delete";
            //DelColumn.UseColumnTextForButtonValue = true;
            //loansGridView.Columns.Add(DelColumn);
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
