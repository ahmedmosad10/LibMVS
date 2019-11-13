using LibMVP.Logic.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibMVP.Views.Forms
{
    public partial class frm_Category : Form,Icatgory
    {
        CatgoryPresenter catgoryPresenter;
        //public int ID { get; set; }
        //public string CatName { get; set; }
        public frm_Category()
        {
            InitializeComponent();
            catgoryPresenter = new CatgoryPresenter(this);
        }
        #region Icatgory Members

        public int ID
        {
            get
            {
                return Convert.ToInt32(txtID.Text);
                //throw new NotImplementedException();
            }
            set
            {
                txtID.Text = value.ToString();
                // throw new NotImplementedException();
            }
        }

        public string CatName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        #endregion
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ID =Convert.ToInt32( txtID.Text);
            //CatName = txtName.Text;
          bool check=  catgoryPresenter.CatInsert();
          if (check==true)
          {
              MessageBox.Show("تم الاضافة بنجاح");
          }
          else
          {
              MessageBox.Show("noooooooooooooo");

          }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool check = catgoryPresenter.CatUpdata();
            if (check == true)
            {
                MessageBox.Show("تم التعديل بنجاح ");
            }
            else
            {
                MessageBox.Show("خطأ");

            }
        }




        private void btnDel_Click(object sender, EventArgs e)
        {
            bool check = catgoryPresenter.CatDelete();
            if (check == true)
            {
                MessageBox.Show("تم الحذف بنجاح ");
            }
            else
            {
                MessageBox.Show("خطأ");

            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            bool check = catgoryPresenter.CatDeleteAll();
            if (check == true)
            {
                MessageBox.Show("تم الحذف  الكل بنجاح ");
            }
            else
            {
                MessageBox.Show("خطأ");

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            catgoryPresenter.ClearFildes();
        }






        

       

       
    }
}
