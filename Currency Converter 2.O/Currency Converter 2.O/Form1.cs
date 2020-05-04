using Newtonsoft.Json.Linq;
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

namespace Currency_Converter_2.O
{
    public partial class Form1 : Form
    {
        string q,query;
        string converted_curr;
    //    var details="not";
        public Form1()
        {
            InitializeComponent();
            string url = "http://data.fixer.io/api/latest?access_key=30ee5265c6c0dc4ec17deeba4dfa9271";
            converted_curr = GET(url);
           
        }
        string GET(string url)
        {

         //   log.Error("Into GET");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {                
                throw;
            }
         //  log.Error("End of the GET function");
        }
        private void Coverted_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var details = JObject.Parse(converted_curr);
            q = (string)query;

            textBox2.Text = (string)details["rates"][q];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = comboBox1.Text;
        ;
            
        }
    }
}


