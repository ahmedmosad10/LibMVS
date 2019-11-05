using LibMVP.Logic.Servcies;
using LibMVP.Models;
using LibMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Logic.Presenter
{
    class CatgoryPresenter
    {
        Icatgory icatgory;
        CatgoryModel catModel = new CatgoryModel();
        public CatgoryPresenter(Icatgory view )
        {
            this.icatgory = view;
        }
        public void ConnectBettwenModelInterface()
        {
            catModel.ID = icatgory.ID;
            catModel.CatName = icatgory.CatName;
        }
        public bool CatInsert()
        {
            ConnectBettwenModelInterface();
            return CatgoryService.categoryInsert(catModel.ID, catModel.CatName);
        }

    }
}
