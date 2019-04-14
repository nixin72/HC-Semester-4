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
        public int employeeid { get; set; }
        public String lname { get; set; }
        public String fname { get; set; }
        public int posId { get; set; }
        public int supervisor { get; set; }
        public DateTime hiredate { get; set; }
        public int salary { get; set; }
        public int commission { get; set; }
        public int deptid { get; set; }
        public int qualid { get; set; }

        public Employee()
        {
            this.employeeid = 0;
            this.lname = "";
            this.fname = "";
            this.posId = 0;
            this.supervisor = 0;
            this.hiredate = DateTime.Now;
            this.salary = 0;
            this.commission = 0;
            this.deptid = 0;
            this.qualid = 0;
        }

        public Employee(int empId, String lname, String fname, int sal, int comm)
        {
            this.employeeid = empId;
            this.lname = lname;
            this.fname = fname;
            this.posId = 0;
            this.supervisor = 0;
            this.hiredate = DateTime.Now;
            this.salary = sal;
            this.commission = comm;
            this.deptid = 0;
            this.qualid = 0;
        }

        public void updateEmployee()
        {
            EmployeeDB empDB = new EmployeeDB();
            empDB.updateEmployeeInfo(this.employeeid, this.lname, this.fname, this.salary, this.commission);
        }

    }
}
