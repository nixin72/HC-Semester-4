using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentInfo.App_Code;

namespace StudentInfo {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //if (!Page.IsPostBack) {
            //    panDis.Enabled = false;
            //    //DisableControls(Page, false);
            //}
            //else {
            //    Course progIV = new Course(4507, "420B42", "Programming 4", "WN15", "Hamilton");
            //    Course dataII = new Course(4503, "420D20", "Database managment 2", "WN15", "Hamilton");
            //    Course webIV  = new Course(4502, "420C40", "Web Programming 4", "WN15", "McDonald");

            //    ddlCourses.Items.Add(progIV.CourseDisplay());
            //    ddlCourses.Items.Add(dataII.CourseDisplay());
            //    ddlCourses.Items.Add(webIV.CourseDisplay());
            //    panDis.Enabled = true;
            //}            
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            
        }
    }
}