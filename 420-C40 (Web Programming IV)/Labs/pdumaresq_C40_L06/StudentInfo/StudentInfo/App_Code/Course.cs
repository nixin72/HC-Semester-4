using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code {
    public class Course {
        public int csid { get; set; }
        public String courseid { get; set; }
        public String courseTitle { get; set; }
        public String termId { get; set; }
        public String facultyName { get; set; }

        public Course() {
            this.csid = 0;
            this.courseid = "";
            this.courseTitle = "";
            this.termId = "";
            this.facultyName = "";
        }

        public Course(int csid, String courseid) {
            this.csid = csid;
            this.courseid = courseid;
            this.courseTitle = "";
            this.termId = "";
            this.facultyName = "";
        }

        public Course(int csid, String courseid, 
            String title, String term, String faculty) {
            this.csid = csid;
            this.courseid = courseid;
            this.courseTitle = title;
            this.termId = term;
            this.facultyName = faculty; 
        }

        public String CourseDisplay() {
            return courseid + "/" + courseTitle + "/" + termId + "/" + facultyName;
        } 
    }
}