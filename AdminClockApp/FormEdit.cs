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

namespace AdminClockApp
{
    public partial class FormEdit : DevExpress.XtraEditors.XtraForm
    {

        public FormEdit()
        {
            InitializeComponent();
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            this.setDefaultEnable();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseCategories = client.GetAsync("Categories/GetCategories").Result;
            var empCategories = responseCategories.Content.ReadAsAsync<List<Categories>>().Result;
        
            loadDataPro();          
            dataGridView1.DataSource = empCategories;
            this.dataGridView1.Columns[1].HeaderText = "TITLE";
            dataGridView1.Columns[0].Visible = false;
            this.txtTitle1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

            comboBox1.DataSource = empCategories;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "title";
            

        }
        private void loadDataPro()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            HttpResponseMessage responseProducts = client.GetAsync("Products/GetProducts").Result;
            var empProducts = responseProducts.Content.ReadAsAsync<List<Products>>().Result;
            
            int numrow = 0;
            
            if (empProducts.Count == 0) 
            {
                dataGridView2.DataSource = empProducts;
                MessageBox.Show("empty");
                txtTitle.Text = "";
                txtDetail.Text = "";
                txtPrice.Text = "";
                pictureBox1.Image = null;
            }
            else {

                dataGridView2.DataSource = empProducts;
                comboBox1.DisplayMember = "title";
                txtTitle.Text = dataGridView2.Rows[numrow].Cells[2].Value.ToString();
                txtDetail.Text = dataGridView2.Rows[numrow].Cells[3].Value.ToString();
                txtPrice.Text = dataGridView2.Rows[numrow].Cells[4].Value.ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = this.ByteToImg(dataGridView2.Rows[numrow].Cells[5].Value.ToString());
                this.dataGridView2.Columns[2].HeaderText = "TITLE";
                this.dataGridView2.Columns[3].HeaderText = "PRICE";
                this.dataGridView2.Columns[4].HeaderText = "DETAIL";
                
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                dataGridView2.Columns[5].Visible = false;
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                Program.idPro = (int)dataGridView2.Rows[numrow].Cells[0].Value;
                comboBox1.SelectedValue = dataGridView2.Rows[numrow].Cells[1].Value;
                comboBox1.DisplayMember = dataGridView2.Rows[numrow].Cells[1].Value.ToString();
                txtTitle.Text = dataGridView2.Rows[numrow].Cells[2].Value.ToString();
                txtDetail.Text = dataGridView2.Rows[numrow].Cells[3].Value.ToString();
                txtPrice.Text = dataGridView2.Rows[numrow].Cells[4].Value.ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = this.ByteToImg(dataGridView2.Rows[numrow].Cells[5].Value.ToString());
                Program.imgText = dataGridView2.Rows[numrow].Cells[5].Value.ToString();
            }

            else
            {
                MessageBox.Show("empty");
                txtTitle.Text = "";
                txtDetail.Text = "";
                txtPrice.Text = "";
                pictureBox1.Image = null;
            }
        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            Categories categories = new Categories(txtTitle1.Text, Program.idCat);
            switch (Program.flag)
            {

                case 1:
                    if (txtTitle1.Text == "")
                    {
                        MessageBox.Show("Title is empty");
                    }
                    else
                    {
                        HttpResponseMessage responePost = client.PostAsJsonAsync("Categories/PostCategories", categories).Result;
                        int returnValue = responePost.Content.ReadAsAsync<int>().Result;

                        MessageBox.Show("Add Complete +"+ returnValue.ToString());
                        this.txtTitle1.Enabled = false;
                        this.btnSaveCat.Enabled = false;
                        this.btnDelCat.Enabled = true;
                        this.btnUpCat.Enabled = true;
                        this.btnRefCat.Enabled = true;
                        this.standaloneBarDockControl2.Enabled = true;
                        Program.flag = 0;
                    }
                    break;
                case 2:
                    //Categories categories1 = new Categories(txtTitle1.Text,Program.idCat);
                    HttpResponseMessage responePut = client.PutAsJsonAsync("Categories/PutCategories/" + Program.idCat, categories).Result;
                    MessageBox.Show("Update Complete");
                    setDefaultEnable();
                    Program.flag = 0;
                    break;
                default:
                    break;
            }


        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.FormEdit_Load(sender, e);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Program.uri);
                HttpResponseMessage response = client.DeleteAsync("Categories/DeleteCategories/" + Program.idCat).Result;

                MessageBox.Show("Delete Complete");
            }

        }

        private void btnAddCat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.flag = 1;
            this.txtTitle1.Text = "";
            this.txtTitle1.ReadOnly = false;
            this.groupBox3.Enabled = true;
            this.txtTitle1.Enabled = true;
            this.btnSaveCat.Enabled = true;
            this.btnCancelCat.Enabled = true;
            this.btnDelCat.Enabled = false;
            this.btnUpCat.Enabled = false;
            this.btnRefCat.Enabled = false;
            this.standaloneBarDockControl2.Enabled = false;
        }

        private void btnUpCat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.flag = 2;
            this.groupBox3.Enabled = true;
            this.standaloneBarDockControl2.Enabled = false;
            this.groupBox4.Enabled = false;
            this.txtTitle1.Enabled = true;
            this.btnAddCat.Enabled = false;
            this.btnDelCat.Enabled = false;
            this.btnRefCat.Enabled = false;
            this.txtTitle1.ReadOnly = false;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int numrow = e.RowIndex;
            if (numrow >= 0)
            {
                Program.idCat = (int)dataGridView1.Rows[numrow].Cells[0].Value;
                this.txtTitle1.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            } else
            {
                this.txtTitle1.Text = "";
            }
            

        }

        private void btnAddPro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.flag = 1;
            this.setDefaultValue();
            this.unReadOnly();
            this.standaloneBarDockControl3.Enabled = false;
            this.groupBox3.Enabled = false;
            this.groupBox4.Enabled = true;
            this.btnDelPro.Enabled = false;
            this.btnUpPro.Enabled = false;
            this.btnRefPro.Enabled = false;
            this.btnSavePro.Enabled = true;
            this.btnCancelPro.Enabled = true;
            this.labelImage.Visible = true;
            this.btnChoseImage.Visible = true;
        }

        private void btnSavePro_Click(object sender, EventArgs e)
        {
            Products products = new Products(txtTitle.Text, txtDetail.Text, txtPrice.Text, Program.imgText, (int)comboBox1.SelectedValue, Program.idPro);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Program.uri);
            switch (Program.flag)
            {
                case 1:
                    //txtIDCategories.SelectedText = (string)comboBox1.SelectedValue;
                    if (txtTitle.Text == "")
                    {
                        MessageBox.Show("Title is empty!!!");
                    }
                    else if (txtPrice.Text == "")
                    {
                        MessageBox.Show("Price is empty");
                    }
                    else if (txtDetail.Text == "")
                    {
                        MessageBox.Show("Detail is empty");
                    }
                    else if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("Image is empty");
                    }
                    else {
                        HttpResponseMessage respone = client.PostAsJsonAsync("Products/PostProducts", products).Result;
                        MessageBox.Show("Add Complete");
                        setDefaultEnable();
                        Program.flag = 0;                   
                    }
                    break;
                case 2:
                    if (txtTitle.Text == "")
                    {
                        MessageBox.Show("Title is empty!!!");
                    }
                    else if (txtPrice.Text == "")
                    {
                        MessageBox.Show("Price is empty");
                    }
                    else if (txtDetail.Text == "")
                    {
                        MessageBox.Show("Detail is empty");
                    }
                    else if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("Image is empty");
                    }
                    else
                    {
                        HttpResponseMessage respone1 = client.PutAsJsonAsync("Products/PutProducts/" + Program.idPro, products).Result;
                        MessageBox.Show("Update Complete");
                        setDefaultEnable();
                        Program.flag = 0;
                        
                    }
                    break;
            
                default:
                    break;
            }
        }
        private void setDefaultValue()
        {
            this.txtTitle.Text = "";
            this.txtPrice.Text = "";
            this.txtDetail.Text = "";
            this.txtTitle1.Text = "";
            this.pictureBox1.Image = null;
        }
        private void setDefaultEditPro()
        {
            this.setDefaultEnable();
            this.txtTitle.Enabled = true;
            this.txtDetail.Enabled = true;
            this.txtPrice.Enabled = true;
        }
        private void setDefaultEditCat()
        {
            this.setDefaultEnable();
            this.txtTitle1.Enabled = true;
        }
        private void setDefaultEnable()
        {
            this.standaloneBarDockControl3.Enabled = true;
            this.standaloneBarDockControl2.Enabled = true;
            this.btnAddCat.Enabled = true;
            this.btnDelCat.Enabled = true;
            this.btnUpCat.Enabled = true;
            this.btnRefCat.Enabled = true;
            this.btnAddPro.Enabled = true;
            this.btnUpPro.Enabled = true;
            this.btnDelPro.Enabled = true;
            this.btnRefPro.Enabled = true;
            this.btnChoseImage.Visible = false;
            this.labelImage.Visible = false;
            this.readOnly();
        }
        private void unReadOnly()
        {
            this.txtTitle.ReadOnly = false;
            this.txtPrice.ReadOnly = false;
            this.txtDetail.ReadOnly = false;
            this.txtTitle1.ReadOnly = false;
            this.txtTitle1.ReadOnly = false;
            this.comboBox1.Enabled = true;
        }
        private void readOnly()
        {
            dataGridView1.ReadOnly = true;
            dataGridView2.ReadOnly = true;
            this.txtTitle.ReadOnly = true;
            this.txtPrice.ReadOnly = true;
            this.txtDetail.ReadOnly = true;
            this.txtTitle1.ReadOnly = true;
            this.txtTitle1.ReadOnly = true;
            this.comboBox1.Enabled = false;
        }
        private void btnCancelCat_Click(object sender, EventArgs e)
        {
            this.setDefaultEnable();
            this.setDefaultValue();
        }

        private void btnRefPro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.FormEdit_Load(sender, e);
        }

        private void btnDelPro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Program.uri);
                HttpResponseMessage response = client.DeleteAsync("Products/DeleteProducts/" + Program.idPro).Result;
                MessageBox.Show("Delete Complete");
            }
        }

        private void btnCancelPro_Click(object sender, EventArgs e)
        {
            this.setDefaultEnable();
            this.setDefaultValue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Program.strImg = openFile.FileName;
                Program.imgText = Convert.ToBase64String(converImgToByte());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = Program.strImg;
            }
        }
        private byte[] converImgToByte()
        {
            FileStream fs;
            fs = new FileStream(Program.strImg, FileMode.Open, FileAccess.Read);
            byte[] picbyte = new byte[fs.Length];
            fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();
            return picbyte;
        }
        private Image ByteToImg(string byteString)
        {
            byte[] imgBytes = Convert.FromBase64String(byteString);
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnUpPro_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.flag = 2;
            this.standaloneBarDockControl3.Enabled = false;
            this.groupBox4.Enabled = true;
            this.txtTitle.ReadOnly = false;
            this.txtPrice.ReadOnly = false;
            this.txtDetail.ReadOnly = false;
            this.groupBox3.Enabled = false;
            this.btnAddPro.Enabled = false;
            this.btnDelPro.Enabled = false;
            this.btnRefPro.Enabled = false;
            this.labelImage.Visible = true;
            this.btnChoseImage.Visible = true;
        }

        private void standaloneBarDockControl2_Click(object sender, EventArgs e)
        {

        }
    }
}