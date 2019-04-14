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
        public void updateEmployeeInfo(int empNum, string lName, string fName, int salary, int commission)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Update nn_employee 
                                set lname = :last, 
                                    fname = :first,
                                    salary = :sal,
                                    commission = :comm
                              where employeeid= :empID";
            OracleCommand cmd = new OracleCommand(cmdStr, con);
            cmd.Parameters.Add("last", lName);
            cmd.Parameters.Add("first", fName);
            cmd.Parameters.Add("sal", salary);
            cmd.Parameters.Add("comm", commission);
            cmd.Parameters.Add("empID", empNum);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.UpdateCommand = cmd;

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

        public void insertEmployee(string lName, string fName, int posID, int super, DateTime hireDate, int salary, int commission, int deptID, int qualID)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OracleConnection con = new OracleConnection(conString);
            string cmdStr = @"Insert into nn_employee
                                (employeeID,
                                 lName,
                                 fName,
                                 positionID,
                                 SUPERVISOR, 
                                 HIREDATE, 
                                 SALARY, 
                                 COMMISSION, 
                                 DEPTID, 
                                 QUALID) 
                            VALUES(NN_EMPLOYEE_SEQ.NEXTVAL, 
                                   :LNAME, 
                                   :FNAME, 
                                   :POSITIONID, 
                                   :SUPERVISOR, 
                                   :HIREDATE,    
                                   :SALARY, 
                                   :COMMISSION, 
                                   :DEPTID, 
                                   :QUALID)";
            OracleCommand cmd = new OracleCommand(cmdStr, con);

        }
    }
}
