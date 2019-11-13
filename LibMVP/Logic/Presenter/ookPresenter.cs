using LibMVP.Logic.Servcies;
using LibMVP.Models;
using LibMVP.Views.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Logic.Presenter
{
    class ookPresenter
    {
        Iook iook;
        ookModel okModel = new ookModel();
        public ookPresenter(Iook view)
        {
            this.iook = view;
        }

        public void ConnectBettwenModelInterface()
        {
            
            okModel.ID = iook.ID;
            okModel.bookName = iook.BookName;
            okModel.bb = iook.bb.ToArray();
            
        }
        public bool ookInsert()
        {
            ConnectBettwenModelInterface();
            bool check = ookService.ookInsert(okModel.ID,okModel.bookName,okModel.bb);
            //CountyService.CountyInsert(contryModel.ID,contryModel.CountyName);
            // CatgoryService.categoryInsert(catModel.ID, catModel.CatName);
            //getAllData();
            //AutoNumber();
            return check;
        }

        public bool contryUpdata()
        {
          //  ConnectBettwenModelInterface();
          //// bool check  = CountyService.Countyupdata(contryModel.ID, contryModel.CountyName);
          //  getAllData();
          //  AutoNumber();
          // // return check;
            return false;
        }

        public bool CountryDelete()
        {
            //ConnectBettwenModelInterface();
            //bool check //= CountyService.CountyDelete(contryModel.ID);
            //getAllData();
            //AutoNumber();
           // return check;
            return false;
        }

        public bool countryDeleteAll()
        {
           // ConnectBettwenModelInterface();
            //bool check = CountyService.CountryDeleteAll();
            //getAllData();
            //AutoNumber();
           // return check;
            return false;
        }
        public DataTable getdatabyid()
        {
            ConnectBettwenModelInterface();
            return ookService.getbyid(okModel.ID);
           
        }
        public void ClearFildes()
        {
           // ConnectBettwenModelInterface();
           //icontry.ID = 0;// icatgory.ID = 0;
           // icontry.CountyName = ""; //icatgory.CatName = "";
        }

        public void getAllData()
        {
         //   DataTable tbl = new DataTable();
         //   ConnectBettwenModelInterface();
         //return tbl = iook.datagridview = ookService.getAllData();// CountyService.getAllData();
            iook.datagridview = ookService.getAllData();// CountyService.getAllData();

           // //ClearFildes();
          // return CountyService.getAllData();
        }

        public void AutoNumber()
        {
            //// ConnectBettwenModelInterface();
            //icontry.ID = CountyService.getAllData().Rows.Count + 1;
            //icontry.CountyName = "";
        }
    }

}

