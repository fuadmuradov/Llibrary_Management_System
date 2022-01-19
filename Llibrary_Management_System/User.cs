using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Llibrary_Management_System
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void readersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddReader rd = new AddReader();
            rd.ShowDialog();
        }
    }
}
