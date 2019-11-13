using LibMVP.Logic.Servcies;
using LibMVP.Models;
using LibMVP.Views;
using LibMVP.Views.InterFace;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Logic.Presenter
{
    public class CountryPresenter
        
    {
        Icounty icontry;
        CountyModel contryModel = new CountyModel();

        public CountryPresenter(Icounty view)
        {
            this.icontry = view;
        }

        public void ConnectBettwenModelInterface()
        {
            contryModel.ID = icontry.ID;
            contryModel.CountyName = icontry.CountyName;
        }
        public bool CountInsert()
        {
            ConnectBettwenModelInterface();
            bool check= CountyService.CountyInsert(contryModel.ID,contryModel.CountyName);// CatgoryService.categoryInsert(catModel.ID, catModel.CatName);
            getAllData();
            AutoNumber();
            return check;
        }

        public bool contryUpdata()
        {
            ConnectBettwenModelInterface();
            bool check = CountyService.Countyupdata(contryModel.ID, contryModel.CountyName);
            getAllData();
            AutoNumber();
            return check;
        }

        public bool CountryDelete()
        {
            ConnectBettwenModelInterface();
            bool check = CountyService.CountyDelete(contryModel.ID);
            getAllData();
            AutoNumber();
            return check;
        }

        public bool countryDeleteAll()
        {
            ConnectBettwenModelInterface();
            bool check = CountyService.CountryDeleteAll();
            getAllData();
            AutoNumber();
            return check;
        }
        public void ClearFildes()
        {
            ConnectBettwenModelInterface();
           icontry.ID = 0;// icatgory.ID = 0;
            icontry.CountyName = ""; //icatgory.CatName = "";
        }

        public void getAllData()
        {
           // ConnectBettwenModelInterface();
            
            icontry.datagridview = CountyService.getAllData();
            //icontry.datagridview = 
            //ClearFildes();
          //  return CountyService.getAllData();
        }

        public void AutoNumber()
        {
            // ConnectBettwenModelInterface();
            icontry.ID = CountyService.getAllData().Rows.Count + 1;
            icontry.CountyName = "";
        }
    }
}
