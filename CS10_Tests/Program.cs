using CS10_Tests2;
using System;

namespace CS10_Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //var structImprovements = new Struct_Improvements();
            //structImprovements.StrucUsage();

            //var classToExecute = new CallerExpresssionArgumentFeature();
            ////classToExecute.CallingMethod();
            //classToExecute.Dispose();
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            //Console.WriteLine();
            //GC.SuppressFinalize(classToExecute);
            //classToExecute.CallingMethod();
            //Console.WriteLine(+classToExecute);

            //var example = new AsyncMethodBuilderExample();
            //example.RunMe();

            //var example = new ImprovedDefiniteAssignment();
            //example.ExecuteMe();

            //var exemple = new Record_Structs();
            //exemple.ExecuteMe();    

            //Console.WriteLine("[main] Constructing");
            //var classToExecute = new CallerExpressionArgumentFeature();
            //classToExecute.CallingMethod();
            //MyMethod(1);
            ////Console.WriteLine("[main] Disposing [object 0]");
            //classToExecute.Dispose();
            ////Console.WriteLine("[main] GC Collecting");
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //Console.WriteLine("[main] Done");
            //Console.ReadKey();

            //var classToExecute = new InterpolatedStringHandlerFeature();
            //classToExecute.ExecuteMe();

            //var example = new ExtendedPropertyPatterns();                        
            //example.RunMe();


            //var example = new Attribute_Lambda_Expressions();
            //example.ExecuteMe();


            var exemple = new Deconstruction();
            exemple.Example();
        }

        private static void MyMethod(int i)
        {
            new CallerExpressionArgumentFeature();
        }
    }
}