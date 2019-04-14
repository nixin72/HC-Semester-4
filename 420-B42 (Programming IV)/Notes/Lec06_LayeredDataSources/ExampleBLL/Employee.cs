using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleDB;

namespace ExampleBLL
{
    public class Employee
    {
        public int empNum { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string qualification { get; set; }

        public Employee()
        {

        }

        public List<Employee> getCustomerInfo()
        {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.DataTableEmpInfoDataTable datatable = empDB.getFullEmployeeInfo();
            return getEmployees(datatable);
        }

        //public Employee getEmployeeInfo(int empID) {
        //    EmployeeDB empDB = new EmployeeDB();
        //    dsNaman.DataTableEmpInfoDataTable datatable = empDB.getFullEmployeeInfo();
        //    return getEmployees(datatable);
        //}

        public int getTotalSalary()
        {
            EmployeeDB empDB = new EmployeeDB();
            int retVal = empDB.getTotalSalary();
            return retVal;
        }

        private List<Employee> getEmployees(dsNaman.DataTableEmpInfoDataTable datatable)
        {
            List<Employee> employees = new List<Employee>();
            if (datatable != null)
            {
                for (int i=0; i<datatable.Rows.Count; i++)
                {
                    try
                    {
                        Employee emp = new Employee();
                        emp.empNum = Convert.ToInt32(datatable.Rows[i]["EMPLOYEEID"].ToString());
                        emp.firstName = datatable.Rows[i]["FNAME"].ToString();
                        emp.lastName = datatable.Rows[i]["LNAME"].ToString();
                        emp.position = datatable.Rows[i]["POSDESC"].ToString();
                        emp.department = datatable.Rows[i]["DEPTNAME"].ToString();
                        emp.qualification= datatable.Rows[i]["QUALDESC"].ToString();
                        employees.Add(emp);
                    } catch
                    {
                        //do something
                        Console.Write("Error");
                    }
                }
            } else
            {
                employees = null;
            }
            return employees;
        }
    }
}
