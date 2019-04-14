using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Wrote this class to avoid putting logic into my actual test classes.
 * This class replaces the Unit test libary's basic functionality with the 
 * same class and method names to make replacing the code much easier 
 * when porting over to assignment 2. Trying to reduce the amount of code 
 * I'll need to re-write to make things go smoother, while making it easy to
 * change up my test cases without worrying about breaking them. Logic is 
 * all handled here and I just call the methods from the test classes.
 */
namespace HVK_UnitTesting
{
    class Assert {
        public static new void Equals(Object obj1, Object obj2) {
            bool equal = obj1.Equals(obj2);
            if (!equal)
                Console.Write("-----------------------------ERROR---------------------------\n");
            Console.Write(equal + "\n");
        }

        public static void Equals(Object obj1, Object obj2, String msg) {
            bool equal = obj1.Equals(obj2);
            if (!equal)
                Console.Write("----------------------------ERROR--------------------------\n");
            Console.Write(msg + ": " + equal + "\n");
        }

        public static void ListsEqual<T>(List<T> list1, List<T> list2, String msg) {
            bool equal = list1.SequenceEqual(list2);
            if (!equal)
                Console.Write("---------------------------ERROR--------------------------\n");
            Console.Write(msg + ": " + equal + "\n");
        }
    }
}