using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace HulkHvkDB {
    class HVK_SqlConnection {
        public HVK_SqlConnection() { }

        public static DataTable GetData( string tableName ) {
            string select = "select * from " + tableName + " order by 1";
            return GetData(tableName, select);
        }

        public static DataTable GetData( string tableName, string select ) {
            DataTable dt = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);

            string cmdStr = select;
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try {
                con.Open();
                da.Fill(dt);
            } catch ( Exception ) {
                Console.WriteLine("Error in loading " + tableName);
            } finally {
                con.Close();
                da.Dispose();
            }
            return dt;
        }

        public static int AddRow( string cmdStr ) {

            int result = 0;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try {
                con.Open();
                cmd.ExecuteNonQuery();
            } catch ( Exception ) {
                Console.WriteLine("Error in adding row");
                result = -1;
            } finally {
                con.Close();
                da.Dispose();
            }
            return result;
        }

        public static bool UpdateRow( string cmdStr ) {
            bool success = true;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            string parm1, parm2;
            int index;

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Success in updating table");
            } catch ( Exception ) {
                Console.WriteLine("Error in updating table");
                success = false;
            } finally {
                con.Close();
                da.Dispose();
            }
            return success;
        }

        public static bool Delete( string cmdStr ) {
            bool success = true;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;
            con.Open();
            OracleTransaction trans = con.BeginTransaction();
            cmd.Transaction = trans;

            try {
                cmd.ExecuteNonQuery();
                trans.Commit();
            } catch ( Exception ) {
                trans.Rollback();
                success = false;
                Console.WriteLine("Error in deleting row");
            } finally {
                con.Close();
                da.Dispose();
            }
            return success;
        }
    }
}
