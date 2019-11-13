using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Views.InterFace
{
  public  interface Icounty
    {
        int ID { get; set; }
        string CountyName { get; set; }
        object datagridview { get; set; }
        //byte b { get; set; }
    }
}
