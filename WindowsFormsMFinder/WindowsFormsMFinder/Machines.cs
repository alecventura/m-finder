﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsMFinder
{
    public partial class Machines : Form
    {
        private Dashboard dashboard;

        public Machines()
        {
            InitializeComponent();
        }

        public Machines(Dashboard dashboard)
        {
            // TODO: Complete member initialization
            this.dashboard = dashboard;
        }
    }
}
