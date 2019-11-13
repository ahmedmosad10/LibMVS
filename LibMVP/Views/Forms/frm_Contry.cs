using LibMVP.Logic.Presenter;
using LibMVP.Views.InterFace;
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
    public partial class frm_Contry : Form, Icounty
    {
        CountryPresenter countryPresenter;
        public frm_Contry()
        {
            InitializeComponent();
            countryPresenter = new CountryPresenter(this);
        }
        #region Icounty Members

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

        public string CountyName
        {
            get
            {
                return Convert.ToString( txtName.Text);
            }
            set
            {
                txtName.Text = value.ToString();
            }
        }
        public object datagridview
        {
            get
            {
                return dgvContry.DataSource;
            }
            set
            {
                dgvContry.DataSource = value;
            }
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool check = countryPresenter.CountInsert();
            if (check == true)
            {
                MessageBox.Show("تم الاضافة بنجاح");
            }
            else
            {
                MessageBox.Show("noooooooooooooo");

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
          // countryPresenter.ClearFildes();
            countryPresenter.AutoNumber();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool check = countryPresenter.contryUpdata();
            if (check == true)
            {
                MessageBox.Show("تم التعديل بنجاح");
            }
            else
            {
                MessageBox.Show("noooooooooooooo");

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bool check = countryPresenter.CountryDelete();
            if (check == true)
            {
                MessageBox.Show("تم الحذف بنجاح");
            }
            else
            {
                MessageBox.Show("noooooooooooooo");

            }
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            bool check = countryPresenter.countryDeleteAll();
            if (check == true)
            {
                MessageBox.Show("تم التعديل بنجاح");
            }
            else
            {
                MessageBox.Show("noooooooooooooo");

            }
        }

        private void frm_Contry_Load(object sender, EventArgs e)
        {
            countryPresenter.getAllData();

         //   countryPresenter.AutoNumber();
            countryPresenter.AutoNumber();
        }



      
    }
}
