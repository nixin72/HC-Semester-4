using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExampleDB;

namespace ExampleBLL
{
    public class Department
    {
        public int deptID { get; set; }
        public string deptName { get; set; }
        public string location { get; set; }
        public int empID { get; set; }

        public Department()
        {
            deptID = 0;
            deptName = "";
            location = "";
            empID = 0;
        }

        public Department(string _deptName, string _location)
        {
            this.deptName = _deptName;
            this.location = _location;
        }

        public Department(int _deptID, string _deptName, string _location, int _empID)
        {
            this.deptID = _deptID;
            this.deptName = _deptName;
            this.location = _location;
            this.empID = _empID;
        }

        public void insertDepartment()
        {
            DepartmentDB depDB = new DepartmentDB();
            depDB.insertDept(this.deptName, this.location);
            Console.Write("Done in Class");
        }

        public DataSet fillBox()
        {
            DepartmentDB depDB = new DepartmentDB();
            DataSet vals = depDB.selectDepartments();
            return vals;
        }
    }
}
