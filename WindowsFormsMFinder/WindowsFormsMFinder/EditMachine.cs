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
    public partial class EditMachine : Form, Presenter.InterfaceViews.IEditMachines
    {
        private Machines machines;
        private Presenter.EditMachinesPresenter presenter;
        private int id;

        public EditMachine()
        {
            InitializeComponent();
        }

        public EditMachine(Machines machines)
        {
            InitializeComponent();
            this.machines = machines;
            presenter = new Presenter.EditMachinesPresenter(this);
        }

        public EditMachine(Machines machines, MfinderContext.Machine m)
        {
            InitializeComponent();
            this.machines = machines;
            this.name = m.Name;
            this.model = m.Model;
            this.serialnumber = m.Serialnumber;
            this.id = m.Id;
            if (m.AquisitionDate != null)
            {
                this.aquisitionDate = m.AquisitionDate.Value;
            }
            if (m.WarrantyExpirationDate != null)
            {
                this.warrantyExpirationDate = m.WarrantyExpirationDate.Value;
            }
            presenter = new Presenter.EditMachinesPresenter(this);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            presenter.buttonSave_Click(sender, e);
        }

        public string model
        {
            get
            {
                return this.textBoxModel.Text;
            }
            set
            {
                this.textBoxModel.Text = value;
            }
        }

        public string name
        {
            get
            {
                return this.textBoxName.Text;
            }
            set
            {
                this.textBoxName.Text = value;
            }
        }

        public string serialnumber
        {
            get
            {
                return this.textBoxSerialNumber.Text;
            }
            set
            {
                this.textBoxSerialNumber.Text = value;
            }
        }

        public DateTime aquisitionDate
        {
            get
            {
                return this.dateTimePickerAquisition.Value.Date;
            }
            set
            {
                this.dateTimePickerAquisition.Value = value;
            }
        }

        public DateTime warrantyExpirationDate
        {
            get
            {
                return this.dateTimePickerWarrantExpiration.Value.Date;
            }
            set
            {
                this.dateTimePickerWarrantExpiration.Value = value;
            }
        }

        public void goToMachines()
        {
            machines.updateMachinesList();
            this.Hide();
            machines.Show();
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



        int Presenter.InterfaceViews.IEditMachines.id
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
    }
}
