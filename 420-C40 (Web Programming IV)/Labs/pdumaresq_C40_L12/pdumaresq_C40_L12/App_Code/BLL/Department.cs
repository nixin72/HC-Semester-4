using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using pdumaresq_C40_L12.App_Code.DB;

namespace pdumaresq_C40_L12.App_Code.BLL {
    public class Department {
        public int deptid { get; set; }
        public string deptname { get; set; }

        public Department() {

        }

        public Department(int id, string name) {
            this.deptid = id;
            this.deptname = name;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Department> ListDepartments() {
            DepartmentDB deptDB = new DepartmentDB();
            DataSet data = deptDB.selectAllDepartments();
            return ConvertDepartmentList(data);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public String GetDepartmentById(int id) {
            DepartmentDB deptDB = new DepartmentDB();
            return deptDB.SelectDepartmentById(id);
        }

        private List<Department> ConvertDepartmentList(DataSet data) {
            List<Department> list = new List<Department>();
            foreach (DataRow r in data.Tables[0].Rows) {
                try {
                    Department dept = new Department();
                    dept.deptid = Convert.ToInt16(r[0]);
                    dept.deptname = r[1].ToString();

                    list.Add(dept);
                }
                catch { }
            }

            return data != null ? list : null;
        }
    }
}