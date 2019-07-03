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
    public partial class FormCreateAcc : DevExpress.XtraEditors.XtraForm
    {
        public FormCreateAcc()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
            if (txtUser.Text == "")
            {
                MessageBox.Show("username is empty");
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("password is empty");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Name is empty");
            }else if(txtEmail.Text == "")
            {
                MessageBox.Show("Email is empty");
            }else if (txtAddress.Text == "")
            {
                MessageBox.Show("Address is empty");
            }
            else
            {
                bool isAdmin = true;
                Users users = new Users(txtUser.Text, txtPass.Text, txtName.Text, txtEmail.Text, Int32.Parse(txtPhone.Text), txtAddress.Text, isAdmin);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Program.uri);
                HttpResponseMessage responePost = client.PostAsJsonAsync("Users/postusers", users).Result;
                var returnValue = responePost.Content.ReadAsAsync<Users>().Result;
                MessageBox.Show("Complete");
            }
        }
    }
}