using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace LibMVP.Logic.Servcies
{
   static public class DBHelper
    {
       public static SqlCommand command;
       //this methoud  to get conncetion string from sql server
       public static SqlConnection getConnectionString()
       {
           SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
           builder.DataSource = Properties.Settings.Default.ServerName;
           builder.InitialCatalog = Properties.Settings.Default.DBName;
           builder.IntegratedSecurity = true;
           return new SqlConnection(builder.ConnectionString);

       }
       //this methoud to make insert delete and update all in database in all 
       public static bool excuteData(string spName, Action methoud)
       {
           using(SqlConnection connection = getConnectionString())
               try
               {
                   command = new SqlCommand(spName, connection);
                   command.CommandType = CommandType.StoredProcedure;

                   methoud.Invoke();
                   connection.Open();
                   command.ExecuteNonQuery();
                   connection.Close();
                   return true;
               }
               catch (Exception ex )
               {
                   connection.Close();
                   Console.WriteLine(ex.Message);
                   return false;

               }
               finally 
               { 
                   connection.Close();
               }
           return false;
       }
       //this mouthed getAll data from table 
       public static DataTable GetData(string spName, Action methoud)
       {
           DataTable tbl = new DataTable();
           SqlDataAdapter da;
           using (SqlConnection connection = getConnectionString())
               try
               {
                   command = new SqlCommand(spName, connection);
                   command.CommandType = CommandType.StoredProcedure;

                   methoud.Invoke();
                   connection.Open();
                  // command.ExecuteNonQuery();
                  // tbl.Load(command.ExecuteReader());
                    da = new SqlDataAdapter(command);
                   da.Fill(tbl);
                   da.Dispose();
                   connection.Close();
               }
               catch (Exception ex)
               {
                   connection.Close();
                   Console.WriteLine(ex.Message);

               }
               finally
               {
                   connection.Close();
                   
               }
           return tbl;
           
       }

       
    }
}
