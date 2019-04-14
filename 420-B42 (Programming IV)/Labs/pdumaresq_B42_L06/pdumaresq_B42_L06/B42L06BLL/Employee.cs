using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B42L06DB;

namespace B42L06BLL
{
    public class Employee
    {
        public int number { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String position { get; set; }
        public DateTime hireDate { get; set;}
        public int salary { get; set; }
        public int commission { get; set; }
        public String deptName { get; set; }
        public int deptid { get; set; }
        public String qual { get; set; }

        public Employee() {
            this.number = 0;
            this.firstName = "";
            this.lastName = "";
            this.position = "";
            this.hireDate = DateTime.Now;
            this.salary = 0;
            this.commission = 0;
            this.deptName = "";
            this.deptid = 0;
            this.qual = "";
        }

        public Employee(int empNumber, String first, String last) {
            this.number = empNumber;
            this.firstName = first;
            this.lastName = last;
            this.position = "";
            this.hireDate = DateTime.Now;
            this.salary = 0;
            this.commission = 0;
            this.deptName = "";
            this.deptid = 0;
            this.qual = "";
        }

        public Employee(int empNumber, String first, String last, String position, 
            String deptName, int deptid, String qualdesc, int salary, int commission, DateTime hireDate) {
            this.number = empNumber;
            this.firstName = first;
            this.lastName = last;
            this.position = position;
            this.hireDate = hireDate;
            this.salary = salary;
            this.commission = commission;
            this.deptName = deptName;
            this.deptid = deptid;
            this.qual = qualdesc;
        }

        public List<Employee> getEmployeesByDept(String deptName) {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.EmployeeDigestDataTable data = empDB.GetEmployeesBtDeptName(deptName);
            return getEmployees(data);
        }

        public List<Employee> getEmployeesByLastName(String lName) {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.EmployeeDigestDataTable data = empDB.GetEmployeesByLastName(lName);
            return getEmployees(data);
        }

        public int getNumberEmployeesInDept(int dept) {
            EmployeeDB empDB = new EmployeeDB();
            return empDB.GetCountEmployeesByDept(dept);
        }

        public int getTotalSalaryOfAllEmployees() {
            EmployeeDB empDB = new EmployeeDB();
            return empDB.GetSumEmployeeSalary();
        }

        public int getSumOfSalaryByDept(int dept) {
            EmployeeDB empDB = new EmployeeDB();
            return empDB.GetSumSalaryByDept(dept);
        }

        public List<Employee> getEmployeesOverSalary(int benchmark) {
            EmployeeDB empDB = new EmployeeDB();
            dsNaman.EmployeeDigestDataTable data = empDB.GetEmployeesAboveSalary(benchmark);
            return getEmployees(data);
        }

        private List<Employee> getEmployees(dsNaman.EmployeeDigestDataTable data) {
            List<Employee> employees = new List<Employee>();

            //data.ToList().ForEach(r => employees.Add(new Employee(r.EMPLOYEEID, r.FNAME, r.LNAME, r.POSDESC, 
            //    r.DEPTNAME, r.DEPTID, r.QUALDESC, r.SALARY, r.COMMISSION, r.HIREDATE)));

            if (data != null) {
                for (int i = 0; i < data.Rows.Count; i++) {
                    try {
                        Employee emp = new Employee(Convert.ToInt16(data.Rows[i]["EMPLOYEEID"].ToString()),
                            data.Rows[i]["FNAME"].ToString(),   data.Rows[i]["LNAME"].ToString(),
                            data.Rows[i]["POSDESC"].ToString(), data.Rows[i]["DEPTNAME"].ToString(),
                            Convert.ToInt16(data.Rows[i]["DEPTID"].ToString()),
                            data.Rows[i]["QUALDESC"].ToString(),
                            Convert.ToInt16(data.Rows[i]["SALARY"].ToString()),
                            Convert.ToInt16(data.Rows[i]["COMMISSION"].ToString()),
                            DateTime.Parse(data.Rows[i]["HIREDATE"].ToString()));
                        employees.Add(emp);
                    }
                    catch {

                    }
                }
            }
            else {
                employees = null;
            }
            return employees;
        }
    }
}
