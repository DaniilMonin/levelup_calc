using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ShopManagerARM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://localhost:60672/");

            var request = new RestRequest("api/users", DataFormat.Json);

            var response = client.Get(request);

            List<User> users = JsonConvert.DeserializeObject<List<User>>(response.Content);

            bindingSource1.DataSource = users;
            //response.Content
        }
    }

    public sealed class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
