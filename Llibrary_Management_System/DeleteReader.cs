using Llibrary_Management_System.Model;
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
    public partial class DeleteReader : Form
    {
        private readonly LibraryMSEntities db;

        public DeleteReader()
        {
            InitializeComponent();
            db = new LibraryMSEntities();
        }

      private void  gridviewrefresh()
        {
            dataGridView1.DataSource = db.Readers.Select(x => new
            {
                x.id,
                x.Fullname,
                x.Email,
                x.IdentityNum
            }).ToList();
        }
        private void DeleteReader_Load(object sender, EventArgs e)
        {
            gridviewrefresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtidentity.Text = dataGridView1.Rows[e.RowIndex].Cells["IdentityNum"].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells["Fullname"].Value.ToString();







        }

        private void btndelete_Click(object sender, EventArgs e)
        {
             string name = txtname.Text;
            string identity = txtidentity.Text;
            if (name == "" || identity == "")
            {
                MessageBox.Show("Fill all textbox", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reader reader = db.Readers.FirstOrDefault(x => x.IdentityNum == identity);
            if (reader==null)
            {
                MessageBox.Show("This Not Reader !", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            db.Readers.Remove(reader);
            db.SaveChanges();
            gridviewrefresh();

            txtname.Text = "";
            txtidentity.Text = "";

        }
    }
}
