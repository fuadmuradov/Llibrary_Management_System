using Llibrary_Management_System.Model;
using Llibrary_Management_System.ViewModel;
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
    public partial class AddBook : Form
    {
        private readonly LibraryMSEntities db;
        public static int bookid;
        public AddBook()
        {
            InitializeComponent();
            db = new LibraryMSEntities();
        }

        public void datagridrefresh()
        {
            dataGridView1.DataSource = db.Books.Where(x=>x.isDeleted==false).Select(x => new
            {
                x.id,
                x.Name,
                x.Writer,
                x.Amount,
                x.Price,
                Genre = x.Genre.Name

            }).ToList();
        }

        private void cleartxt()
        {
            txtAddName.Text = "";
            txtwriter.Text = "";
            txtamount.Value = 0;
            txtprice.Value = 0;
            txtSearchname.Text = "";
        }
        private void AddBook_Load(object sender, EventArgs e)
        {
            cmbGenre.DataSource = db.Genres.Select(x => new CB_Genre
            {
                id = x.id,
                Name = x.Name
            }).ToArray();

            datagridrefresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int genreid = ((CB_Genre)cmbGenre.SelectedItem).id;
            string name = txtAddName.Text;
            string writer = txtwriter.Text;
            int amount = int.Parse(txtamount.Value.ToString());
            double price = double.Parse(txtprice.Value.ToString());
    
            bool checkdb = db.Books.Any(x => x.Name == name && x.isDeleted==false);



            if (name == "" || writer == "" || amount ==0 || price ==0 )
            {
                MessageBox.Show("Please Fill All TextBox !!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkdb)
            {
                MessageBox.Show("This Book Already Exist !!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book book1 = db.Books.FirstOrDefault(x => x.Name == name);

            if (book1==null || book1.isDeleted == true)
            {
                Book book = new Book
                {
                    Name = name,
                    Writer = writer,
                    Amount = amount,
                    Price = price,
                    isDeleted = false,
                    genreId = genreid,
                };

                db.Books.Add(book);
                db.SaveChanges();
                datagridrefresh();
                cleartxt();
                return;
            }

            if (book1.isDeleted==false)
            {
                MessageBox.Show("This Book Already Exist !!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int genreid = ((CB_Genre)cmbGenre.SelectedItem).id;
            string name = txtAddName.Text;
            string writer = txtwriter.Text;
            int amount = int.Parse(txtamount.Value.ToString());
            double price = double.Parse(txtprice.Value.ToString());


            if (name == "" || writer == "" || amount == 0 || price == 0)
            {
                MessageBox.Show("Please Fill All TextBox !!!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book book = db.Books.FirstOrDefault(x => x.id == bookid);

            book.Name = name;
            book.Writer = writer;
            book.Amount = amount;
            book.Price = price;
            book.isDeleted = false;
            book.genreId = genreid;

            db.SaveChanges();
            datagridrefresh();
            cleartxt();



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchname = txtSearchname.Text;

            if (searchname == "")
            {
                MessageBox.Show("Please Fill Search Textbox", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool checkbook = db.Books.Any(x => x.Name == searchname);
           

            if (!checkbook)
            {
                MessageBox.Show("This Book Not Exist", "Warning",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book book = db.Books.FirstOrDefault(x => x.Name == searchname && x.isDeleted==false);
            if (book==null)
            {
                MessageBox.Show("This Book Deleted", "Warning",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                db.SaveChanges();

                dataGridView1.DataSource = db.Books.Where(x => x.Name == searchname && x.isDeleted==false).Select(x => new
                {
                    x.id,
                    x.Name,
                    x.Writer,
                    x.Amount,
                    x.Price,
                    Genre = x.Genre.Name

                }).ToList();
                bookid = book.id;
                txtAddName.Text = book.Name;
                txtwriter.Text = book.Writer;
                txtamount.Value = book.Amount;
                txtprice.Value = decimal.Parse(book.Price.ToString());
                cmbGenre.SelectedIndex = cmbGenre.FindString(book.Genre.Name);
            }

        }
    }
}
