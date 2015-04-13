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
    public partial class EditMachine : Form
    {
        private Machines machines;

        public EditMachine()
        {
            InitializeComponent();
        }

        public EditMachine(Machines machines)
        {
            InitializeComponent();
            this.machines = machines;
        }
    }
}
