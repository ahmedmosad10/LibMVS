using LibMVP.Logic.Presenter;
using LibMVP.Views.InterFace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace LibMVP.Views.Forms
{
    public partial class frm_ook : Form,Iook
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True");

      ookPresenter  okPresenter;
      MemoryStream ms;
      byte[] photo_aray;
    //  FileStream fs;

      SqlConnection con;
     SqlCommand cmd;
     int rowindex = -1;

        public frm_ook()
        {
            InitializeComponent();
            okPresenter = new ookPresenter(this);
        }

        #region Iook Members

        public int ID
        {
            get
            {
                return Convert.ToInt32(txtID.Text);
            }
            set
            {
                txtID.Text = value.ToString();
            }
        }

        public string BookName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value.ToString();
            }
        }
        byte[] Iook.bb
        {
            get
            {
                // throw new NotImplementedException();
               
                    ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] photo_aray = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(photo_aray, 0, photo_aray.Length);

                
                return photo_aray;
            }
            set
            {
              //  throw new NotImplementedException();
                photo_aray = value.ToArray();
            }
        }
        public object datagridview
        {
            get
            {
                return dgvook.DataSource;
            }
            set
            {
                dgvook.DataSource = value;
            }
        }
        #endregion
      //  SqlCommand cmd;
        void conv_photo()
        {
            //converting photo to binary data
            if (pictureBox1.Image != null)
            {
                ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@bookimg", photo_aray);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = okPresenter.ookInsert(); ;// countryPresenter.CountInsert();
            if (check == true)
            {
                MessageBox.Show("تم الاضافة بنجاح");
            }
            else
            {
                MessageBox.Show("noooooooooooooo");

            }
            //cmd = new SqlCommand("insertook", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ID",txtID.Text);
            //cmd.Parameters.AddWithValue("@bookname",txtName.Text);
            //conv_photo();
            //conn.Open();
            //int n = cmd.ExecuteNonQuery();
            //conn.Close();
            //if (n > 0)
            //{
            //    MessageBox.Show("record inserted");
            //}
            //else
            //    MessageBox.Show("insertion failed");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void frm_ook_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("user id=sa;password=123;database=prash");
            okPresenter.getAllData();// countryPresenter.getAllData();
            dgvook.Columns[2].Visible = false;

            menu.ItemClicked += delegate(object Mysender, ToolStripItemClickedEventArgs MyE)
            {
                if (MyE.ClickedItem.Name == "Edit")
                {
                    MessageBox.Show("تحرير");
                }
            };


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //int n = Convert.ToInt32(Interaction.InputBox("Enter sno:", "Search", "20", 100, 100));
            DataTable tbl = new DataTable();
            tbl = okPresenter.getdatabyid();
            if (tbl.Rows.Count >0)
            {
                txtID.Text = tbl.Rows[0][0].ToString();//CountyService.getAllData().Rows.Count 
                txtName.Text = tbl.Rows[0][1].ToString();
                if (tbl.Rows[0][2] != System.DBNull.Value)
                {
                    photo_aray = (byte[])tbl.Rows[0][2];
                    MemoryStream ms = new MemoryStream(photo_aray);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("no have data for this record");
            }
            

        }

        private void dgvook_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rowindex = dgvook.HitTest(e.X, e.Y).RowIndex;
                if (rowindex > -1)
                {
                    dgvook.ClearSelection();
                    dgvook.Rows[rowindex].Selected = true;
                    menu.Show(dgvook, e.Location);
                    //MessageBox.Show(""+rowindex);
                }
            }
        }

        private void dgvook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = dgvook.SelectedRows[0];
           txtID.Text = dr.Cells[0].Value.ToString();
            // or simply use column name instead of index
            //dr.Cells["id"].Value.ToString();
          txtName.Text = dr.Cells[1].Value.ToString();
            //textBox3.Text = dr.Cells[2].Value.ToString();
          //if (dr.Cells[2].Value==System.DBNull)
          if (dr.Cells[2].Value==DBNull.Value)
          {
              MessageBox.Show("no have pic For this Item");
          }
          else
          {
              
              var data = (Byte[])(dr.Cells[2].Value);
              var stream = new MemoryStream(data);
              pictureBox1.Image = Image.FromStream(stream);
          }
         
        }




       
    }
}
