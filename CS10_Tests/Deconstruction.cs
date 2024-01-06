using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests
{
    internal class Deconstruction
    {
        public void Example()
        {
            var valueTuple = (ValueAsInt: 5, ValueAsString: "5", ValueAsFloat: 5.0f);

            //Tuple<int, string, float> tuple = Tuple.Create(5, "5", 5.0f);

            //int newValueAsInt = 0;
            string newValueAsString;
            float newValueAsFloat;
            (int newValueAsInt, newValueAsString, newValueAsFloat) = valueTuple;

            Console.WriteLine(newValueAsInt);
            Console.WriteLine(newValueAsString);
            Console.WriteLine(newValueAsFloat);            

            ////(int newValueAsInt, string newValueAsString, float newValueAsFloat) = tuple;

            ////int newValueAsInt = 0;
            //int newValueAsInt;
            ////string newValueAsString;
            ////float newValueAsFloat;
            //(newValueAsInt, string newValueAsString, float newValueAsFloat) = tuple;
            ////(newValueAsInt, newValueAsString, newValueAsFloat) = tuple;




            //var tuple = ValueTuple.Create(5, "5", 5.0f);
            ////(int newValueAsInt, string newValueAsString, float newValueAsFloat) = tuple;

            //int newValueAsInt;
            //(newValueAsInt, string newValueAsString, float newValueAsFloat) = tuple;


            //(int, string, float) tuple2 = (5, "5", 5.0f);
            //Console.WriteLine(tuple2.GetType());
            //Console.WriteLine(tuple.Item1);
            //Console.WriteLine(tuple.Item2);
            //Console.WriteLine(tuple.Item3);

            int valueAsInt = 5;
            string valueAsString = "5";
            float valueAsFloat = 5.0f;
            var tuple3 = (valueAsInt, valueAsString, valueAsFloat);
            Console.WriteLine(tuple3.GetType());
        }
    }
}
