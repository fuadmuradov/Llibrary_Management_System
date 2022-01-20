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
    public partial class AdminPage : Form
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void deleteBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteBook dltbook = new DeleteBook();
            dltbook.Show();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Register rgst = new Register();
            rgst.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser dltuser = new DeleteUser();
            dltuser.Show();
        }

        private void userDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
        }
    }
}
