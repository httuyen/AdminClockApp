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
    public partial class FormLogin : DevExpress.XtraEditors.XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUserAd.Text == Program.userAd)
            {
                if (txtPassAd.Text == Program.passwordAd)
                {
                    FormMain formMain = new FormMain();
                    this.Visible = false;
                    formMain.Visible = true;
                }
                else {
                    MessageBox.Show("Password is incorrect");
                    return;
                }
            }
            else {
                for (int i = 0; i <= Program.dict.Count; i++)
                {
                    if (i == Program.dict.Count)
                    {
                        MessageBox.Show("Username is not exist");
                        break;
                    }
                    if (txtUserAd.Text == Program.dict.Keys.ElementAt(i).ToString())
                    {
                        Program.userAd = Program.dict.Keys.ElementAt(i).ToString();
                        Program.dict.TryGetValue(Program.userAd, out Program.passwordAd);
                        if (txtUserAd.Text == Program.userAd)
                        {
                            if (txtPassAd.Text == Program.passwordAd)
                            {
                                FormMain formMain = new FormMain();
                                this.Visible = false;
                                formMain.Visible = true;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Password is incorrect");
                                break;
                            }
                        }
                        break;
                    }

                }
            }
        }
            
        private void FormLogin_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseUsers = client.GetAsync("Users/GetUsersbyAd?isAdmin=true").Result;
            var empUser = responseUsers.Content.ReadAsAsync<List<Users>>().Result;
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (Users item in empUser)
            {
                dict.Add(new KeyValuePair<string, string>(item.username, item.password));
            }
            Program.dict = (Dictionary<string, string>)dict;
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
            }
        }
    }
}