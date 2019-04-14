using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExampleDB;

namespace ExampleBLL
{
    public class Departement
    {
        public int deptid { get; set; }
        public String name { get; set; }
        public String location { get; set; }
        public int empId { get; set; }

        public Departement()
        {
            this.deptid = 0;
            this.name = "";
            this.location = "";
            this.empId = 0;
        }

        public Departement(int deptid, String location)
        {
            this.deptid = deptid;
            this.name = "";
            this.location = location;
            this.empId = 0;
        }

        public Departement(int deptid, String location, String name, int empid)
        {
            this.deptid = deptid;
            this.name = name;
            this.location = location;
            this.empId = empid;
        }

        public DataSet fillBox()
        {
            DepartementDB deptDB = new DepartementDB();
            DataSet vals = deptDB.SelectDepartments();
            return vals;
        }
    }
}
