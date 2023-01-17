using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_final
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void filmEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.filmEkle.Show();
            this.Hide();
        }

        private void filmGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.filmGuncelle.Show();
            this.Hide();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.filmSil.Show();
            this.Hide();
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.filmAra.Show();
            this.Hide();
        }

        private void tümFilmlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Router.tumFilmler.Show();
            this.Hide();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            if (DbClass.dbconnect.State == ConnectionState.Closed)
            {
                DbClass.dbconnect.Open();
            }
            fetchapidata();
        }

        void fetchapidata()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.openweathermap.org/data/2.5/weather?q=bursa&units=metric&lang=tr&appid=e83b1748c912441f42a45d625ff37c03");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(result);
                    label1.Text = $"Bursa: {data["main"]["temp"].ToString()} derece";
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
