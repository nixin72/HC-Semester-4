using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkDB;
using System.Data;

namespace HulkHvkBLL {
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

        public Run( int num, char size ) {
            this.number = num;
            this.size = size;
            this.covered = 'y';
            this.location = 'f';
            this.status = 0;
        }
        public Run( int num, char size, char covered, char location, int status ) {
            this.number = num;
            this.size = size;
            this.covered = covered;
            this.location = location;
            this.status = status;
        }

        public override bool Equals( Object run ) {
            if ( run.GetType() == typeof(Run) ) {
                Run run2 = (Run)run;
                return ((this.size == run2.size)
                    && (this.covered == run2.covered)
                    && (this.location == run2.location));
            } else
                return false;
        }

        public List<Run> ListRuns() {
            RunDB run = new RunDB();
            DataTable data = run.GetFullRunInfo();
            return GetRuns(data);
        }

        private List<Run> GetRuns( DataTable data ) {
            List<Run> list = new List<Run>();
            foreach ( DataRow r in data.Rows ) {
                try {
                    int num = Convert.ToInt16(r[0]);
                    char s = r[1].ToString().ElementAt(0);
                    char c = r[2] != DBNull.Value ? r[2].ToString().ElementAt(0) : '~';
                    char l = r[3] != DBNull.Value ? r[3].ToString().ElementAt(0) : '~';
                    int s2 = r[4] != DBNull.Value ? Convert.ToInt16(r[4]) : -1;
                    list.Add(new Run(
                        num, s, c, l, s2
                    ));
                } catch { }
            };

            return data != null ? list : null;
        }
    }
}
