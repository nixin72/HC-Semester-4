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
    public class DepartmentDB
    {
        public DataSet selectDepartments()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = "Select deptID, deptName from NN_dept order by deptName";
            OracleCommand cmd = new OracleCommand(cmdStr, con);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataSet ds = new DataSet("deptDataSet");

            da.Fill(ds, "nn_dept");
            return ds;
        }

        public void insertDept(string dName, string loc)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into NN_DEPT
                                (deptID,
                                 deptName,
                                 location)
                            VALUES(NN_DEPT_SEQ.NEXTVAL, 
                                   :DEPTNAME, 
                                   :LOCATION)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("deptName", dName);
            cmd.Parameters.Add("location", loc);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.InsertCommand = cmd;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("Did not work");
            }
            finally
            {
                con.Close();
            }



        }
    }
}
