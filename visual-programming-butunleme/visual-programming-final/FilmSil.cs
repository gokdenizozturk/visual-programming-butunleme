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
    public partial class FilmSil : Form
    {
        public FilmSil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            if (id != "")
            {
                string query = $"DELETE FROM filmler WHERE id='{id}'";
                MySqlCommand sqlCommand = new MySqlCommand(query, DbClass.dbconnect);
                sqlCommand.ExecuteNonQuery();
                yenile();
                MessageBox.Show("silme başarılı");
            }
            else
            {
                MessageBox.Show("ilgili alanları doldurunuz!");
            }
        }
        void yenile()
        {
            string query = "select * from filmler";
            MySqlDataAdapter mySqlData = new MySqlDataAdapter(query,DbClass.dbconnect);
            DataTable dataTable = new DataTable();
            mySqlData.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void FilmSil_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void FilmSil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Router.anaForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Router.anaForm.Show();
        }
    }
}
