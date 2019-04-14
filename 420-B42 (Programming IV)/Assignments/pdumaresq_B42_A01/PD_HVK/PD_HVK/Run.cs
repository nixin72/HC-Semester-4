using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Run {
        public int number { get; set; }
        public char size { get; set; }
        public char covered { get; set; }
        public char location { get; set; }
        public int status { get; set; }

        public Run() {
            this.number = 0;
            this.size = 's';
            this.covered = 'y';
            this.location = 'f';
            this.status = 0;
        }

        public Run(int num, char size) {
            this.number = num;
            this.size = size;
            this.covered = 'y';
            this.location = 'f';
            this.status = 0;
        }
        public Run(int num, char size, char covered, char location, int status) {
            this.number = num;
            this.size = size;
            this.covered = covered;
            this.location = location;
            this.status = status;
        }

        public override bool Equals(Object run) {
            if (run.GetType() == typeof(Run)) {
                Run run2 = (Run)run;
                return ((this.size == run2.size)
                    && (this.covered == run2.covered)
                    && (this.location == run2.location));
            }
            else
                return false;
        }
    }
}
