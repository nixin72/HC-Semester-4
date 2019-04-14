using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace pdumaresq_C40_L12.App_Code.DB {
    public class FacultyDB {
        public DataSet selectAllFaculty() {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT facultyid, name 
                FROM iu_faculty 
                ORDER BY name
            ";

            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsFac");
            da.Fill(ds, "iu_faculty");
            return ds;
        }

        public DataSet SelectFacultyById(int facultyId) {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT facultyid, name, roomid, phone, deptid
                FROM iu_faculty 
                WHERE facultyid = :FACULTYID
                ORDER BY name
            ";
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            cmd.Parameters.Add("FACULTYID", facultyId);


            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsFac");
            da.Fill(ds, "iu_faculty");
            return ds;
        }
    }
}