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
    public partial class FilmEkle : Form
    {
        public FilmEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filmadi = textBox1.Text.Trim();
            string cikisTar = dateTimePicker1.Text;
            string oyuncular = richTextBox1.Text;
            string imdbscore = comboBox1.Text;
            if (filmadi != "" && cikisTar!=""&&oyuncular!=""&&imdbscore!="")
            {
                string query = $"INSERT INTO filmler (isim, cikistarihi, oyuncular, imdbscore) VALUES('{filmadi}','{cikisTar}','{oyuncular}','{imdbscore}')";
                MySqlCommand sqlCommand = new MySqlCommand(query,DbClass.dbconnect);
                
                
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                MessageBox.Show("ilgili alanları doldurunuz!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FilmEkle_FormClosing(object sender, FormClosingEventArgs e)
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
