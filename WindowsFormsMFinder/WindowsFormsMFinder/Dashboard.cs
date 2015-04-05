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
    public partial class Dashboard : Form
    {
        private Login login;

        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(Login login)
        {
            InitializeComponent();
            this.login = login;
        }
    }
}
