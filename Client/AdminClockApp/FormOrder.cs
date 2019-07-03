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
    public partial class FormOrder : DevExpress.XtraEditors.XtraForm
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseOrders = client.GetAsync("orders/getorders").Result;
            var empProducts = responseOrders.Content.ReadAsAsync<List<Orders>>().Result;
            dataGridView1.DataSource = empProducts;
        }
    }
}