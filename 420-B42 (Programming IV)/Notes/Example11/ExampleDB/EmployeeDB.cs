using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ExampleDB
{
    public class EmployeeDB
    {
        public void updateEmployeeInfo(int empNum, String lname, String fname, int salary, int commission)
        {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            String cmdStr = @"UPDATE nn_employee
                                SET lname = :last,
                                SET fname = :first,
                                SET salary = :sal,
                                SET commission = :comm
                              WHERE employeeid = :empId";

            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("last", lname);
            cmd.Parameters.Add("first", fname);
            cmd.Parameters.Add("sal", salary);
            cmd.Parameters.Add("comm", commission);
            cmd.Parameters.Add("empId", empNum);
            

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

            try {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch {
                Console.WriteLine("Didn't work");
            }
            finally {
                con.Clone();
            }

        }
    }
}
