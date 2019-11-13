using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace LibMVP.Logic.Servcies
{
    static class CatgoryService
    {
        //this mouthed insert in table catogry
        public static bool categoryInsert(int id,string name)
        {
            return  DBHelper.excuteData("categoryInsert", () => catgoryParmaterInsert(id, name, DBHelper.command));
        }
        //this mouthed  give Parmater to use to insert in table catogry
        private static void catgoryParmaterInsert(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        }

        //this mouthed Delete in table catogry
        public static bool categoryDelete(int id)
        {
            return DBHelper.excuteData("categoryDelete", () => catgoryParmaterDelete(id, DBHelper.command));
            
        }
        //this mouthed  give Parmater to use to Delete in table catogry

        private static void catgoryParmaterDelete(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //this mouthed updata in table catogry
        public static bool categoryUpdata(int id, string name)
        {
            return DBHelper.excuteData("categoryUpdate", () => catgoryParmaterUpdata(id, name, DBHelper.command));
           
        }
        //this mouthed  give Parmater to use to updata in table catogry

        private static void catgoryParmaterUpdata(int id, string name, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
        }

        //this mouthed Delete all in table catogry
        public static bool categoryDeleteAll()
        {
            return DBHelper.excuteData("categoryDeleteAll", () => catgoryParmaterDeleteAll());

        }
        //this mouthed  give Parmater to use to Delete all in table catogry

        private static void catgoryParmaterDeleteAll()
        {
            //command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }


    }
}
