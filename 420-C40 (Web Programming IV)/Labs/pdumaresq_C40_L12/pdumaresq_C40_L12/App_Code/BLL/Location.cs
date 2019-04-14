using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using pdumaresq_C40_L12.App_Code.DB;

namespace pdumaresq_C40_L12.App_Code.BLL {
    public class Location {
        public int roomid { get; set; }
        public string roomlocation { get; set; }
        public Location() {

        }

        public Location(int id, string location) {
            this.roomid = id;
            this.roomlocation = location;
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Location> ListLocations() {
            LocationDB locDB = new LocationDB();
            DataSet data = locDB.selectAllLocations();
            return ConvertDepartmentList(data);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public String GetLocationByRoomId(int id) {
            LocationDB locDB = new LocationDB();
            return locDB.SelectFacultyByRoomid(id);
        }

        private List<Location> ConvertDepartmentList(DataSet data) {
            List<Location> list = new List<Location>();
            foreach (DataRow r in data.Tables[0].Rows) {
                try {
                    Location loc = new Location();
                    loc.roomid = Convert.ToInt16(r["roomid"]);
                    loc.roomlocation = r["info"].ToString();

                    list.Add(loc);
                }
                catch { }
            }

            return data != null ? list : null;
        }
    }
}