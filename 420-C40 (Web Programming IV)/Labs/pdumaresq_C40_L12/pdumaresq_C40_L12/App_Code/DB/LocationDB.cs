using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace pdumaresq_C40_L12.App_Code.DB {
    public class LocationDB {
        public DataSet selectAllLocations() {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT roomid, building || '-' || roomno AS info
                FROM iu_location
            ";

            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsLocation");
            da.Fill(ds, "iu_location");
            return ds;
        }

        public String SelectFacultyByRoomid(int roomid) {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT roomid, building || '-' || roomno AS info
                FROM iu_location 
                WHERE roomid = :ROOMID
            ";
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            cmd.Parameters.Add("roomid", roomid);


            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsLocation");
            da.Fill(ds, "iu_location");

            return ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["info"].ToString() : null;
        }
    }
}