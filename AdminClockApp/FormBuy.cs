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
using System.IO;
using System.Collections;
using System.Threading;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Configuration;

namespace AdminClockApp
{
    public partial class FormBuy : DevExpress.XtraEditors.XtraForm
    {
        public FormBuy()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnOkSales_Click(object sender, EventArgs e)
        {
            string dateCreate = DateTime.Now.ToString("dd/MM/yyyy " + "hh:mm:ss");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            Orders orders = new Orders(Program.idOrderReturn, txtCustumer.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text, dateCreate);
            if (txtCustumer.Text == "")
            {
                MessageBox.Show("Custumer is empty!!!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show("Email is empty!!!");
            }
            else if (txtPhone.Text == "")
            {
                MessageBox.Show("Phone Number is empty!!!");
                
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Address is empty!!!");
            }
            else
            {
                HttpResponseMessage respone = client.PostAsJsonAsync("Orders/PostOrders", orders).Result;
                Program.idOrderReturn = respone.Content.ReadAsAsync<int>().Result;
                foreach (OrderDetail item in Program.list1)
                {
                    item.id_order = Program.idOrderReturn;
                    HttpResponseMessage responeOrderDetail = client.PostAsJsonAsync("OdersDetails/PostOdersDetail", item).Result;
                }
                MessageBox.Show("Please wait for seconds");
                XtraReport1 xtra = new XtraReport1();
                xtra.DataSource = Program.listReport;
                xtra.ShowPreviewDialog();
            }
            
        }
            
        private void FormBuy_Load(object sender, EventArgs e)
        {
            Program.dictCat.Clear();
            setDefault();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseProducts = client.GetAsync("Products/GetProducts").Result;
            var empProducts = responseProducts.Content.ReadAsAsync<List<Products>>().Result;

            HttpResponseMessage responseCategories = client.GetAsync("Categories/GetCategories").Result;
            var empCategories = responseCategories.Content.ReadAsAsync<List<Categories>>().Result;
            foreach (Categories item in empCategories)
            {
                Program.dictCat.Add(new KeyValuePair<int, string>(item.id, item.title));
            }
            this.dataGridView4.Columns.Add("titleCategory", "CATEGORY");
            int numrow = 0;
            
            if (empProducts.Count == 0)
            {
                this.dataGridView4.Columns.Add("titleCategory", "CATEGORY");
                this.dataGridView4.DataSource = empProducts;
                MessageBox.Show("empty");
                txtCat.Text = "";
                txtTitle.Text = "";
                txtDetail.Text = "";
                txtPrice.Text = "";
                pictureBox1.Image = null;
            }
            else
            {
                this.dataGridView4.DataSource = empProducts;
                for (int i = 0; i < empProducts.Count; i++)
                {
                    string value = "";
                    Program.dictCat.TryGetValue((int)dataGridView4.Rows[i].Cells[2].Value, out value);
                    dataGridView4.Rows[i].Cells[0].Value = value;
                }
                dataGridView4.ReadOnly = true;
                txtCat.Text = dataGridView4.Rows[numrow].Cells[0].Value.ToString();
                txtTitle.Text = dataGridView4.Rows[numrow].Cells[3].Value.ToString();
                txtDetail.Text = dataGridView4.Rows[numrow].Cells[4].Value.ToString();
                txtPrice.Text = dataGridView4.Rows[numrow].Cells[5].Value.ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = this.ByteToImg(dataGridView4.Rows[numrow].Cells[6].Value.ToString());
                this.dataGridView4.Columns[3].HeaderText = "TITLE";
                this.dataGridView4.Columns[5].HeaderText = "PRICE";
                this.dataGridView4.Columns[4].HeaderText = "DETAIL";
                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Columns[1].Visible = false;
                dataGridView4.Columns[2].Visible = false;
                dataGridView4.Columns[6].Visible = false;
            }
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                Program.idPro = (int)dataGridView4.Rows[numrow].Cells[1].Value;
                string value;
                Program.dictCat.TryGetValue((int)dataGridView4.Rows[numrow].Cells[2].Value, out value);
                txtCat.Text = value;
                //txtCat.Text = dataGridView4.Rows[numrow].Cells[0].Value.ToString();
                txtTitle.Text = dataGridView4.Rows[numrow].Cells[3].Value.ToString();
                txtDetail.Text = dataGridView4.Rows[numrow].Cells[4].Value.ToString();
                txtPrice.Text = dataGridView4.Rows[numrow].Cells[5].Value.ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = this.ByteToImg(dataGridView4.Rows[numrow].Cells[6].Value.ToString());
            }
            else
            {

                MessageBox.Show("empty");
                txtCat.Text = "";
                txtTitle.Text = "";
                txtDetail.Text = "";
                txtPrice.Text = "";
                pictureBox1.Image = null;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 1;
            
            OrderDetail orderDetail = new OrderDetail(Program.idOrderReturn, Program.idPro, txtPrice.Text, Program.quantity);
            
            if(Program.list1.Count == 0)
            {
                Program.list1.Add(orderDetail);
            }
            else
            {
                while (flag == 1)
                {
                    for (int i = 1; i <= Program.list1.Count; i++)
                    {
                        //MessageBox.Show(Program.list1[0].product_id.ToString());
                        if (Program.idPro == Program.list1[i - 1].product_id)
                        {
                            Program.list1[i - 1].quantity += 1;
                            //MessageBox.Show(Program.list1[i - 1].quantity.ToString());
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == 0) break;
                    else
                    {
                        orderDetail = new OrderDetail(Program.idOrderReturn, Program.idPro, txtPrice.Text, Program.quantity);
                        Program.list1.Add(orderDetail);
                        break;
                    }
                }
            }
            
           
            //Program.size --;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            //MessageBox.Show(Program.list1.Count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCart formCart = new FormCart();
            formCart.Show();
            //this.FormBuy_Load(sender,e);
        }
        private void setDefault()
        {
            this.txtCat.ReadOnly = true;
            this.txtDetail.ReadOnly = true;
            this.txtPrice.ReadOnly = true;
            this.txtTitle.ReadOnly = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
           
            
           
        }
    }
}