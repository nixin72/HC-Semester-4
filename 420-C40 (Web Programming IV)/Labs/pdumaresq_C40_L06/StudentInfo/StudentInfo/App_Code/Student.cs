using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code {
    public class Student {
        public int studentid { get; set; }
        public String last { get; set; }
        public String first { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zip { get; set; }
        public String startterm { get; set; }
        public DateTime birthdate { get; set; }
        public int facultyid { get; set; }
        public int majorid { get; set; }
        public String phone { get; set; }

        public Student() {
            this.studentid = 0;
            this.last = "";
            this.first = "";
            this.street = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.startterm = "";
            this.birthdate = new DateTime();
            this.facultyid = 0;
            this.majorid = 0;
            this.phone = "";
        }

        public Student(int id, String last, String first) {
            this.studentid = id;
            this.last = last;
            this.first = first;
            this.street = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.startterm = "";
            this.birthdate = new DateTime();
            this.facultyid = 0;
            this.majorid = 0;
            this.phone = "";
        }

        public Student(int id, String last, String first, String street, 
            String city, String state, String zip, String start, DateTime birth,
            int faculty, int major, String phone) {
            this.studentid = id;
            this.last = last;
            this.first = first;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.startterm = start;
            this.birthdate = birth;
            this.facultyid = faculty;
            this.majorid = major;
            this.phone = phone;
        }
    }
}