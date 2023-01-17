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
    public partial class TumFilmler : Form
    {
        public TumFilmler()
        {
            InitializeComponent();
        }

        private void TumFilmler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Router.anaForm.Show();
        }

        private void TumFilmler_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Router.anaForm.Show();
        }
    }
}
