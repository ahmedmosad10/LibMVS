using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Views.InterFace
{
    interface Iook
    {
        int ID { get; set; }
        string BookName { get; set; }
        object datagridview { get; set; }
        byte []bb { get; set; }
    }
}
