using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdminClockApp
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //FormEdit formEdit = new FormEdit();
            //formEdit.MdiParent = this;
            //formEdit.Show();
            Form frm = this.checkExists(typeof(FormEdit));
            if (frm != null) frm.Activate();
            else
            {
                FormEdit f = new FormEdit();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Visible = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormChangePW formChangePW = new FormChangePW();
            formChangePW.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormUsers formUsers = new FormUsers();
            //formUsers.MdiParent = this;
            //formUsers.Show();
            Form frm = this.checkExists(typeof(FormUsers));
            if (frm != null) frm.Activate();
            else
            {
                FormUsers f = new FormUsers();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FormBuy formBuy = new FormBuy();
            //formBuy.MdiParent = this;
            //formBuy.Show();
            Form frm = this.checkExists(typeof(FormBuy));
            if (frm != null) frm.Activate();
            else
            {
                FormBuy f = new FormBuy();
                f.MdiParent = this;
                f.Show();
            }
        }
        private Form checkExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.checkExists(typeof(FormOrder));
            if (frm != null) frm.Activate();
            else
            {
                FormOrder f = new FormOrder();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormCreateAcc formCre = new FormCreateAcc();
            formCre.Show();
            
        }
    }
}

