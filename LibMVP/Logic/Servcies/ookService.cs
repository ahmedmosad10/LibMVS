using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMVP.Logic.Servcies
{
    static class ookService
    {

        //this mouthed add data in table country
        public static bool ookInsert(int id, string name,byte[] img)
        {
            return DBHelper.excuteData("insertook", () => ookParmaterInsert(id, name, img, DBHelper.command));
        }
        //this mouthed  give Parmater to use to insert in table country
        private static void ookParmaterInsert(int id, string name,byte[] img, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@bookname", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@bookimg", SqlDbType.Binary).Value = img;
            // command.Parameters.Add("@img",SqlDbType.Image)
        }

        //this mouthed updata data in table country
        public static bool ookupdata(int id, string name)
        {
            return DBHelper.excuteData("CountyUpdate", () => ookParmaterUpdata(id, name, DBHelper.command));
        }
        //this mouthed  give Parmater to use to updata in table country
        private static void ookParmaterUpdata(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        }

        //this mouthed delete data in table country
        public static bool ookDelete(int id)
        {
            return DBHelper.excuteData("CountryDelete", () => countryParmaterDelete(id, DBHelper.command));
        }
        //this mouthed  give Parmater to use to updata in table country
        private static void countryParmaterDelete(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //this mouthed Delete all in table Country
        public static bool ookDeleteAll()
        {
            return DBHelper.excuteData("CountryDeleteAll", () => ookParmaterDeleteAll());

        }
        //this mouthed  give Parmater to use to Delete all in table Country

        private static void ookParmaterDeleteAll()
        {
            //command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }

        //this mouthed Get data in show in datatgridView
        public static DataTable getAllData()
        {
            //DataTable tbl = new DataTable();
            //tbl= DBHelper.GetData("CountryGetAll", () => { });
            //return tbl;
            return DBHelper.GetData("getAllook", () => { });
        }
        private static void ookParmatergetbyid(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

        }
        public static DataTable getbyid(int id)
        {
            return DBHelper.GetData("getbyidook", () => ookParmatergetbyid(id,DBHelper.command));
        }

    }
}

