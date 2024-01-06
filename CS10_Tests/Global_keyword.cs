using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests.System
{
    public class Object
    {

    }
}

namespace CS10_Tests
{
    internal class Global_keyword
    {
        public void ExecuteMe()
        {
            var exampleInstance = new System.Object();
            var objectInstance = new global::System.Object();
        }
    }
}
