using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Logic.Servcies
{
   static class CountyService
    {
       //this mouthed add data in table country
        public static bool CountyInsert(int id, string name)
        {
            return DBHelper.excuteData("CountryInsert", () => countryParmaterInsert(id, name, DBHelper.command));
        }
        //this mouthed  give Parmater to use to insert in table country
        private static void countryParmaterInsert(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
           // command.Parameters.Add("@img",SqlDbType.Image)
        }

        //this mouthed updata data in table country
        public static bool Countyupdata(int id, string name)
        {
            return DBHelper.excuteData("CountyUpdate", () => countryParmaterUpdata(id, name, DBHelper.command));
        }
        //this mouthed  give Parmater to use to updata in table country
        private static void countryParmaterUpdata(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        }

        //this mouthed delete data in table country
        public static bool CountyDelete(int id)
        {
            return DBHelper.excuteData("CountryDelete", () => countryParmaterDelete(id, DBHelper.command));
        }
        //this mouthed  give Parmater to use to updata in table country
        private static void countryParmaterDelete(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //this mouthed Delete all in table Country
        public static bool CountryDeleteAll()
        {
            return DBHelper.excuteData("CountryDeleteAll", () => CountryParmaterDeleteAll());

        }
        //this mouthed  give Parmater to use to Delete all in table Country

        private static void CountryParmaterDeleteAll()
        {
            //command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }

        //this mouthed Get data in show in datatgridView
        public static DataTable getAllData()
        {
            //DataTable tbl = new DataTable();
            //tbl= DBHelper.GetData("CountryGetAll", () => { });
            //return tbl;
            return DBHelper.GetData("CountryGetAll", () => { });
        }

    }
}
