using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ExampleDB
{
    public class DepartementDB
    {
        public DataSet SelectDepartments()
        {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = "SELECT deptid, deptname FROM nn_dept order by deptname";
            OracleCommand cmd = new OracleCommand(cmdStr, con);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataSet ds = new DataSet("dataSet");
            da.Fill(ds, "nn_dept");
            return ds;
        }

        public void insertDept(String dname, String loc) {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"INSERT INTO nn_dept (
                                deptid, deptname, location
                            ) values (
                                nn_dept_seq.NEXTVAL, :deptname, :location
                            )";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("deptname", dname);
            cmd.Parameters.Add("location", loc);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.InsertCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("error");
            }
            finally
            {
                con.Close();
            }
        }

        
    }
}
