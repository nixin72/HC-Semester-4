using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfo.App_Code {
    public class Survey {
        public int studentId { get; set; }
        public int csid { get; set; }
        public int metExpect { get; set; }
        public int profKnow { get; set; }
        public int fairAssess { get; set; }
        public String comments { get; set; }
        public Boolean contact { get; set; }
        public String contactBy { get; set; }

        public Survey() {
            this.studentId = 0;
            this.csid = 0;
            this.metExpect = 0;
            this.profKnow = 0;
            this.fairAssess = 0;
            this.comments = "";
            this.contact = false;
            this.contactBy = "";
        }

        public Survey(int studId, int csid, Boolean cont) {
            this.studentId = studId;
            this.csid = csid;
            this.metExpect = 0;
            this.profKnow = 0;
            this.fairAssess = 0;
            this.comments = "";
            this.contact = cont;
            this.contactBy = "";
        }

        public Survey(int studId, int csid, int exp, int prof, 
            int fair, String comm, Boolean cont, String method) {
            this.studentId = studId;
            this.csid = csid;
            this.metExpect = exp;
            this.profKnow = prof;
            this.fairAssess = fair;
            this.comments = comm;
            this.contact = cont;
            this.contactBy = method;
        }
    }
}