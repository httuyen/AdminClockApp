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
    public partial class FormCart : DevExpress.XtraEditors.XtraForm
    {
        public FormCart()
        {
            InitializeComponent();
        }

        private void FormCart_Load(object sender, EventArgs e)
        {
            Program.listReport.Clear();
            List<int> listIDPro = new List<int>();
            List<int> listIDCat = new List<int>();
            List<Products> listPro = new List<Products>();
            List<Categories> listCat = new List<Categories>();
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            for (int i = 1; i <= Program.list1.Count; i++) {
                listIDPro.Add(Program.list1[i - 1].product_id);
                
            }
            
            for (int i = 0; i < Program.list1.Count; i++)
            {
                HttpResponseMessage responseProducts = client.GetAsync("Products/GetProducts/" + listIDPro[i]).Result;
                var empProducts = responseProducts.Content.ReadAsAsync<Products>().Result;
                listPro.Add(empProducts);
            }
            for(int i = 0; i< listIDPro.Count; i++)
            {
                listIDCat.Add(listPro[i].id_category);
            }
            for(int i= 0;i< listPro.Count; i++)
            {
                HttpResponseMessage responseCategories = client.GetAsync("Categories/GetCategories/" + listIDCat[i]).Result;
                var empCategories = responseCategories.Content.ReadAsAsync<Categories>().Result;
                listCat.Add(empCategories);
            }
            //dataGridView1.DataSource = listCat;
            string category = "";
            string tenSp = "";
            string detail = "";
            string price = "";
            int quantity = 0;
            int priceOnly = 0;
            Report report = new Report(category, tenSp, detail, price, quantity, priceOnly);
            
            for (int i = 0; i < Program.list1.Count; i++)
            {
                category = listCat[i].title;
                tenSp = listPro[i].title;
                detail = listPro[i].detail;
                price = listPro[i].price;
                quantity = Program.list1[i].quantity;
                priceOnly = Int32.Parse(price) * quantity;
                report = new Report(category, tenSp, detail, price, quantity,priceOnly);
                Program.listReport.Add(report);
            }
            dataGridView1.DataSource = Program.listReport;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[0].HeaderText = "CATEGORY";
            dataGridView1.Columns[1].HeaderText = "TITLE";
            dataGridView1.Columns[2].HeaderText = "DETAIL";
            dataGridView1.Columns[3].HeaderText = "PRICE";
            dataGridView1.Columns[4].HeaderText = "QUANTITY";
            dataGridView1.Columns[5].HeaderText = "TOTAL";
        }
        public void totalPriceOnly()
        {
            
        }
    }
    
}