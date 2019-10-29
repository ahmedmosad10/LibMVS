using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibMVP
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ribbonControl1.Minimized = true;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["frm_Category1"] != null)
            {
                //you can use closing or hiding Method
                Application.OpenForms["frm_Category1"].Close();
                // Application.OpenForms["My_Form_Name"].Hide();
            }
           // bool check = checkUser("Unit", "User_Setting");
            //if (check == true)
            //{
            Views.Forms.frm_Category childForm = new Views.Forms.frm_Category(); //initialize a child form
            //childForm.TopLevel = false; //set it's TopLevel to false
            //Controls.Add(childForm); //and add it to the parent Form
            //childForm.StartPosition = FormStartPosition.Manual;
            //childForm.Location = new Point(Location.X + (Width - childForm.Width) / 2, Location.Y + (Height - childForm.Height) / 2);
            //childForm.BringToFront(); //use this it there are Controls over your form.
            childForm.ShowDialog();
               
           // }
        }
    }
}
