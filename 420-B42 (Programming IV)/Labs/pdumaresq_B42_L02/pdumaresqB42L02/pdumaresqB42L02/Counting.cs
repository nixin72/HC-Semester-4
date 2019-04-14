using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdumaresqB42L02 {
    public class Counting {

        public int countNumbers(String param) {
            return param.Count(char.IsNumber);
        }

        public int countNumbers(Int64 param) {
            return countNumbers(Convert.ToString(param));
        }

        public int countLetters(String param) {
            return param.Count(char.IsLetter);
        }
    }    
}
