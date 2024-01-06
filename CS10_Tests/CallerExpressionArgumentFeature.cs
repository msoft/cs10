using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS10_Tests
{
    
    internal class CallerExpressionArgumentFeature //: IDisposable
    {
        public CallerExpressionArgumentFeature()
        {
            //string calleeSecondArgument = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor...";
            //int firstInteger = 9;
            //int secondInteger = 610;

            //var instance = new CallerExpresssionArgumentFeature();
            //instance.Callee(firstInteger + secondInteger, calleeSecondArgument, true);
            //this.Callee(firstInteger + secondInteger, calleeSecondArgument, true);

        }

        //~CallerExpresssionArgumentFeature()
        //{
        //    this.Callee();
        //    //Dispose(false);
        //}

        //private bool disposed = false;

        //public void Dispose()
        //{
        //    //Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        protected virtual void Dispose(bool disposing)
        {
            //if (!disposed)
            //{
            //    //if (disposing)
            //    //{
            //    //    Console.WriteLine($"[object] Disposing by Dispose()");
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine($"[object] Disposing by ~Finalizer");
            //    //}
            //    //Console.WriteLine($"[object] Disposed");
            //    disposed = true;
            //}
            //else
            //    Console.WriteLine($"[object] Already disposed!");
        }

        //[Example("Uqqzmmzz")]
        public void CallingMethod()
        {
            string calleeSecondArgument = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor...";
            int firstInteger = 9;
            int secondInteger = 610;

            

            //this.Callee(firstInteger + secondInteger, calleeSecondArgument, true);
            //this.Callee(firstInteger + secondInteger, 
            //    string.Format($"{0} {1} {2}", calleeSecondArgument, firstInteger, secondInteger));

            this.Callee(nameof(calleeSecondArgument));


            //MethodBase method = MethodBase.GetCurrentMethod();
            //ExampleAttribute attr = (ExampleAttribute)method.GetCustomAttributes(typeof(ExampleAttribute), true)[0];
        }
        //string value = attr.;


        //public static CallerExpresssionArgumentFeature operator +(CallerExpresssionArgumentFeature a) => a.Callee();
        //private void Callee(int firstArgument, string secondArgument, bool thirdArgument,
        //    [CallerMemberName] string memberName = "")
        //{
        //    Console.WriteLine(memberName);
        //}

        private void Callee(int argument1, string argument2, 
            [CallerArgumentExpression("argument1")] string argument1Expression = "",
            [CallerArgumentExpression("argument2")] string argument2Expression = "")
        {
            Console.WriteLine(argument1Expression);
            Console.WriteLine(argument2Expression);
            //return this;
        }

        private void Callee(string argument,
            [CallerArgumentExpression("argument")] string argumentExpression = "")
        {
            Console.WriteLine(argumentExpression);
            //return this;
        }

        //public void Callee(int firstArgument, string secondArgument, bool thirdArgument,
        //    [CallerMemberName] string memberName = "",
        //    [CallerFilePath] string sourceFilePath = "",
        //    [CallerLineNumber] int sourceLineNumber = 0)
        //{
        //    Console.WriteLine(firstArgument);
        //    //Trace.WriteLine(firstArgument);

        //    Console.WriteLine(secondArgument);
        //    //Trace.WriteLine(secondArgument);

        //    Console.WriteLine(thirdArgument);
        //    //Trace.WriteLine(thirdArgument);

        //    Console.WriteLine(memberName);
        //    Console.WriteLine(sourceFilePath);
        //    Console.WriteLine(sourceLineNumber);
        //}

        //public void Callee(int firstArgument, string secondArgument, bool thirdArgument,
        //    [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
        //[System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
        //[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0,
        //[CallerArgumentExpression("firstArgument")] string? message = null)
        //{
        //    Console.WriteLine(firstArgument);
        //    Console.WriteLine(secondArgument);

        //    Console.WriteLine(memberName);
        //    Console.WriteLine(sourceFilePath);
        //    Console.WriteLine(sourceLineNumber);
        //    Console.WriteLine(message);

        //}
    }

    public class ExampleAttribute: Attribute
    {
        public ExampleAttribute(string name)
        {
            Callee();
        }

        private void Callee([CallerMemberName] string memberName = "")
        {
            Console.WriteLine(memberName);
            //return this;
        }
    }
}
