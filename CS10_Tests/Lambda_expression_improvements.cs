using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests
{
    internal class Lambda_expression_improvements
    {

        public void Check()
        {
            int result = GetResult("45"); 
            Console.WriteLine(result);

        }

        public delegate int AddDelegate(int a, int b);
        private int GetResult(string s) 
        {
            //var parse = (string s) => int.Parse(s);
            //Func<string, int> parse = (string s) => int.Parse(s);

            //var parse = (string s) => int.Parse(s);
            //Func<string, int> parse = (string s) => int.Parse(s);
            //var parse = (string s) => int.Parse(s);
            //Delegate parse = (string s) => int.Parse(s);
            Delegate parse = (string s) => int.Parse(s);
            var parse2 = (string s) => int.Parse(s);

            var read = Console.Read;

            Func<int, int, int> addWithFunc = (a, b) => a + b;
            Delegate addWithFunc6 = (int a, int b) => a + b;
            object addWithFunc7 = (int a, int b) => a + b;
            //var addWithFunc3 = (a, b) => a + b;
            var addWithFunc4 = object (int a, int b) => a > b ? 0 : "1";
            Delegate addWithFunc5 = object (int a, int b) => a > b ? 0 : "1";


            AddDelegate addWithFunc2 = (int a, int b) => a + b;
            

            //object test = parse;
            return parse2(s);
        }
    }
}
