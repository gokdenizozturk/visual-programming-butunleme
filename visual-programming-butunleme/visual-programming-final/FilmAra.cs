using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace visual_programming_final
{
    public partial class FilmAra : Form
    {
        public FilmAra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filmadi = textBox1.Text.Trim();
            if (filmadi != "")
            {
                string query = $"SELECT * FROM filmler WHERE isim LIKE '{filmadi}'";
                MySqlDataAdapter mySqlData = new MySqlDataAdapter(query, DbClass.dbconnect);
                DataTable dataTable = new DataTable();
                mySqlData.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Lütfen bir film adı girin");
            }
            
        }
        void yenile()
        {
            string query = "select * from filmler";
            MySqlDataAdapter mySqlData = new MySqlDataAdapter(query, DbClass.dbconnect);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void FilmAra_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void FilmAra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Router.anaForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Router.anaForm.Show();
        }
    }
}
