using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using pdumaresq_C40_L12.App_Code.DB;

namespace pdumaresq_C40_L12.App_Code.BLL {
    public class Faculty {
        public int facultyid { get; set; }
        public string facultyName { get; set; }
        public int roomid { get; set; }
        public string phoneNumber { get; set; }
        public int deptid { get; set; }
        public string depname { get; set; }
        public string roomLocation { get; set; }

        public Faculty() {

        }

        public Faculty(int facId, string facName, int roomId, string phone, int deptId, string deptName, string roomLocation) {
            this.facultyid = facultyid;
            this.facultyName = facName;
            this.roomid = roomid;
            this.phoneNumber = phone;
            this.deptid = deptid;
            this.depname = depname;
            this.roomLocation = roomLocation;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Faculty> ListFaculty() {
            FacultyDB facDB = new FacultyDB();
            DataSet data = facDB.selectAllFaculty();
            return ConvertFacList(data);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Faculty GetFacultyByID(int facId) {
            FacultyDB facDB = new FacultyDB();
            DataSet data = facDB.SelectFacultyById(facId);
            return ConvertFac(data);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public Faculty GetFacultyDetailExpanded(int facId) {
            Department dept = new Department();
            Location loc = new Location();
            Faculty data = GetFacultyByID(facId);
            data.depname = dept.GetDepartmentById(data.deptid);
            data.roomLocation = loc.GetLocationByRoomId(data.roomid);

            return data;
        }

        private Faculty ConvertFac(DataSet data) {
            Faculty fac = new Faculty();
            fac.facultyid = Convert.ToInt16(data.Tables[0].Rows[0]["facultyid"]);
            fac.facultyName = data.Tables[0].Rows[0]["name"].ToString();
            fac.phoneNumber = data.Tables[0].Rows[0]["phone"].ToString();
            fac.roomid = !data.Tables[0].Rows[0].IsNull("roomid") ? Convert.ToInt16(data.Tables[0].Rows[0]["roomid"]) : 0;
            fac.deptid = !data.Tables[0].Rows[0].IsNull("deptid") ? Convert.ToInt16(data.Tables[0].Rows[0]["deptid"]) : 0;

            return fac;
        }

        private List<Faculty> ConvertFacList(DataSet data) {
            List<Faculty> list = new List<Faculty>();
            foreach (DataRow r in data.Tables[0].Rows) {
                try {
                    Faculty fac = new Faculty();
                    fac.facultyid = Convert.ToInt16(r["facultyid"]);
                    fac.facultyName = r["name"].ToString();

                    list.Add(fac);
                }
                catch { }
            }

            return data != null ? list : null;
        }
    }
}