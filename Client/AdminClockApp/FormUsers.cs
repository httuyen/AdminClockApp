using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net.Http;

namespace AdminClockApp
{
    public partial class FormUsers : DevExpress.XtraEditors.XtraForm
    {
        public FormUsers()
        {
            InitializeComponent();
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseUsers = client.GetAsync("Users/GetUsersbyAd?isAdmin=true").Result;
            var empUser = responseUsers.Content.ReadAsAsync<List<Users>>().Result;
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (Users item in empUser)
            {
                dict.Add(new KeyValuePair<string, string>(item.username, item.password ));
            }
            Program.dict = (Dictionary<string,string>) dict;
            //for(int i = 0; i< Program.dict.Count; i++)
            //{
            //    MessageBox.Show(Program.dict.Keys.ElementAt(i).ToString()+Program.dict.Values.ElementAt(i).ToString());
            //}
            this.dataGridViewUsers.DataSource = empUser;
            dataGridViewUsers.Columns[0].Visible = false;
            dataGridViewUsers.Columns[7].Visible = false;
            this.dataGridViewUsers.Columns[1].HeaderText = "USERNAME";
            this.dataGridViewUsers.Columns[2].HeaderText = "PASSWORD";
            this.dataGridViewUsers.Columns[3].HeaderText = "NAME";
            this.dataGridViewUsers.Columns[4].HeaderText = "EMAIL";
            this.dataGridViewUsers.Columns[5].HeaderText = "PHONE NUMBER";
            this.dataGridViewUsers.Columns[6].HeaderText = "ADDRESS";
        }
    }
}