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
    public partial class FilmGuncelle : Form
    {
        public FilmGuncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox2.Text.Trim();
            string filmadi = textBox1.Text.Trim();
            string cikisTar = dateTimePicker1.Text;
            string oyuncular = richTextBox1.Text;
            string imdbscore = comboBox1.Text;
            if (filmadi != "" && cikisTar != "" && oyuncular != "" && imdbscore != "" && id!="")
            {
                string query = $"UPDATE filmler SET isim='{filmadi}', cikistarihi='{cikisTar}',oyuncular='{oyuncular}', imdbscore='{imdbscore}' WHERE id='{id}'";
                MySqlCommand sqlCommand = new MySqlCommand(query, DbClass.dbconnect);
                sqlCommand.ExecuteNonQuery();
                yenile();
                MessageBox.Show("Güncelleme başarılı");
            }
            else
            {
                MessageBox.Show("ilgili alanları doldurunuz!");
            }
        }

        private void FilmGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Router.anaForm.Show();
        }

        private void FilmGuncelle_Load(object sender, EventArgs e)
        {
            yenile();
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
            this.Hide();
            Router.anaForm.Show();
        }
    }
}
