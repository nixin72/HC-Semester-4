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
        public string lName { get; set; }
        public string fName { get; set; }
        public int posID { get; set; }
        public int supervisor { get; set; }
        public DateTime hireDate { get; set; }
        public int salary { get; set; }
        public int commission { get; set; }
        public int deptID { get; set; }
        public int qualID { get; set; }

        public Employee()
        {
            empNum = 0;
            lName = "";
            fName = "";
            posID = 0;
            supervisor = 0;
            hireDate = DateTime.MinValue;
            salary = 0;
            commission = 0;
            deptID = 0;
            qualID = 0;
        }

        public Employee(int _empID, string _lName, string _fName, int _salary, int _commission)
        {
            this.empNum = _empID;
            this.lName = _lName;
            this.fName = _fName;
            this.salary = _salary;
            this.commission = _commission;
        }

        public void updateEmployee()
        {
            EmployeeDB empDB = new EmployeeDB();
            empDB.updateEmployeeInfo(this.empNum, this.lName, this.fName, this.salary, this.commission);
        }
    }
}
