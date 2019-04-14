using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresq_B42_A01 {
    public class Discount {
		public int number { get; set; }
		public String desc { get; set; }
		public int per { get; set; }
		public char type { get; set; }
        
		public Discount() {
			this.number = 0;
			this.desc = "";
			this.per = 0;
			this.type = 't';
		}

		public Discount(int num, String desc, int per, char type) {
			this.number = num;
			this.desc = desc;
			this.per = per;
	    	this.type = type;
		}
    }
}
