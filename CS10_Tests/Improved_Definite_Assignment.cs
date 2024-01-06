using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS10_Tests.ImprovedDefiniteAssignment;

namespace CS10_Tests
{
    internal class ImprovedDefiniteAssignment
    {
        public void ExecuteMe()
        {
            ErrorCase1();
        }
        public void TestFeature()
        {
            C c = new C();
            if (c != null && c.M(out object obj0))
            {
                obj0.ToString(); // ok
            }
        }

        public void ErrorCase1()
        {
            C c = new C();
            if ((c != null && c.M(out object obj1)) == true)
            {
                obj1.ToString(); // undesired error
            }

            if ((c != null && c.M(out object obj2)) is true)
            {
                obj2.ToString(); // undesired error
            }
        }
    }

    public class C
    {
        public bool M(out object obj)
        {
            obj = new object();
            return true;
        }
    }
}
