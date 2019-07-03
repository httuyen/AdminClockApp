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

namespace AdminClockApp
{
    public partial class FormChangePW : DevExpress.XtraEditors.XtraForm
    {
        public FormChangePW()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOKPass_Click(object sender, EventArgs e)
        {
            if (txtOldP.Text == Program.passwordAd)
            {
                if (txtNewP.Text == txtCFirmP.Text)
                {
                    Program.passwordAd = txtNewP.Text;
                    MessageBox.Show("Password Changed");
                    this.Close();
                }
                else MessageBox.Show("Confirm password fail.Please enter again");
            }
            else MessageBox.Show("Password Old is not correct. Please enter again");
            
            
        }
    }
}