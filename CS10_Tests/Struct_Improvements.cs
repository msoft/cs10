using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests
{
    internal class Struct_Improvements
    {
        public void StrucUsage()
        {
            StructExample structExample;
            structExample.IntegerMember = 10;
            //var structExample = new StructExample { IntegerMember = 0, StringMember = string.Empty, ClassMember = new ClassExample() };
            Console.WriteLine(structExample.IntegerMember);
            //Console.WriteLine(structExample.StringMember);
            //Console.WriteLine(structExample.ClassMember);

            ClassExample classExample = new ClassExample(10);
            Console.WriteLine(classExample.IntegerMember);

            //var 

            //var firstExample = new StructExample { IntegerMember = 10, StringMember = "First" };
            //var secondExample = firstExample with { StringMember = "Second" };

            //Console.WriteLine(secondExample.IntegerMember);
            //Console.WriteLine(secondExample.StringMember);
        }
    }

    internal struct StructExample
    {
        //public int IntegerMember = 0;
        //public string StringMember = string.Empty;
        //public ClassExample ClassMember = null;

        public int IntegerMember;
        //public string StringMember;
        //public ClassExample ClassMember;

        // Membres
        //private ClassExample classExample = new ClassExample();

        //public int IntegerMember;
        //public string StringMember;

        //~StructExample() { }
        public StructExample(int integerMember)
        {
            this.IntegerMember = integerMember;
            //StringMember = string.Empty;
            //ClassMember = new ClassExample();
        }

        // Constructeur sans paramètre
        //public StructExample()
        //{
        //    //this.ClassMember = new ClassExample();
        //    //this.StringMember = string.Empty;
        //    //this.IntegerMember = 0;
        //}

        // Propriété
        //public ClassExample ClassMember => this.classExample;

        //public StructExample(int integerMember, string stringMember, ClassExample classExample)
        //{
        //    IntegerMember = integerMember;
        //    StringMember = stringMember;
        //    ClassMember = new ClassExample();
        //}
    }


    internal interface StructExample2 
    {
        //public int integerMember;
        //public string stringMember;
        //public ClassExample classExample;

        //public StructExample()
        //{

        //}
    }
    internal class ClassExample
    {
        public int IntegerMember;
        //public string StringMember;

        public ClassExample(int integerMember)
        {
            this.IntegerMember = integerMember;
        }
    }


    
}
