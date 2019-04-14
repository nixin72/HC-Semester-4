using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HulkHvkDB
{
    public class HVK_SqlConnection
    {


        public HVK_SqlConnection()
        {
            
        }// Constructor

        public static DataTable GetData(string tableName)
        {
            string select = "select * from " + tableName;
            return GetData(tableName, select);
        }

        public static DataTable GetData(string tableName, string select)
        {
            
            DataTable dt = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);

            string cmdStr = select;
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try
            {
                con.Open();
                da.Fill(dt);
            }
            catch (Exception)
            {
                Console.WriteLine("Error in loading " + tableName);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
            return dt;  
        }

        public static int AddRow(string cmdStr, string sequence)
        {
            
            int result = 0;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                if (sequence != "") { 
                    cmd.CommandText = "select " + sequence + ".currval from dual";
                    cmd.CommandType = CommandType.Text;
                    result = Int16.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error in adding row");
                result = -1;
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
            return result;
//            int GetOracleSequenceValue()
//        {
//                int seqVal = -1;
//
//                String connString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
//                OracleConnection conn = new OracleConnection(connString);
//                conn.Open();
//
//                OracleCommand cmd = new OracleCommand();
//                cmd.Connection = conn;
//                cmd.CommandText = "select cars_seq.nextval from dual";
//                cmd.CommandType = CommandType.Text;
//                seqVal = Int16.Parse(cmd.ExecuteScalar().ToString());
//
//                return seqVal;
//            }
        }

        public static bool UpdateRow(string cmdStr, List<string> list)
        {
            bool success = true;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            string parm1, parm2;
            int index;
            foreach (string line in list)
            {
                index = line.IndexOf('~');
                parm1 = line.Substring(0, index);
                parm2 = line.Substring(index + 1);
                cmd.Parameters.Add(parm1, parm2);
            }

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;
            
            try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                                            
                }
                catch (Exception)
                {
                    Console.WriteLine("Error in updating table");
                    success = false;
                }
                finally
                {
                    con.Close();
                    da.Dispose();
                }
            return success;
        }

        public static bool Delete(string cmdStr)
        {
            bool success = true;
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                success = false;
                Console.WriteLine("Error in deleting row");
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
            return success;
        }

    }
}
