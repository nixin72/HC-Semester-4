using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace pdumaresq_C40_L12.App_Code.DB {
    public class DepartmentDB {
        public DataSet selectAllDepartments() {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT deptid, deptname 
                FROM iu_department
            ";

            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsDept");
            da.Fill(ds, "iu_department");
            return ds;
        }

        public String SelectDepartmentById(int deptid) {
            String conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Oracle.DataAccess.Client.OracleConnection con = new Oracle.DataAccess.Client.OracleConnection(conString);
            string cmdStr = @"
                SELECT deptid, deptname 
                FROM iu_department 
                WHERE deptid = :DEPTID
            ";
            Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdStr, con);
            cmd.Parameters.Add("DEPTID", deptid);


            Oracle.DataAccess.Client.OracleDataAdapter da = new Oracle.DataAccess.Client.OracleDataAdapter(cmd);
            da.SelectCommand = cmd;
            DataSet ds = new DataSet("dsDeptId");
            da.Fill(ds, "iu_department");

            string retVal = "";
            foreach (DataRow r in ds.Tables[0].Rows) {
                retVal = Convert.ToInt16(r["deptid"]) == deptid ? r["deptname"].ToString() : retVal;
            }

            return retVal;
        }
    }
}