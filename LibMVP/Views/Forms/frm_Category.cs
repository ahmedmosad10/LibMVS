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
              MessageBox.Show("ok");
          }
          else
          {
              MessageBox.Show("noooooooooooooo");

          }
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
    }
}
