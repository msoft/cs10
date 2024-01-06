using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests
{
    internal class Record_Structs
    {
        public void ExecuteMe()
        {
            //var sedan = new Car("Tesla", "3");
            //var suv = sedan with { Model = "X" };

            //var carAsStruct = new CarAsRecordStruct();
            //carAsStruct.Items.Add("4");

        }
    }


    //public readonly record struct CarAsRecordStruct
    //{
    //    public readonly string Brand;// { get; set; }
    //    public string Model { get; }

    //    public readonly List<string> Items = new List<string>();

        
    //    public void ChangeMe(string newBrand)
    //    {
            
    //    }
    //    public CarAsRecordStruct(string brand, string model)
    //    {
    //        this.Brand = brand;
    //        this.Model = model;
    //    }

    //    //public override int GetHashCode()
    //    //{
    //    //    return base.GetHashCode();
    //    //}


    //    //private bool PrintMembers(StringBuilder stringBuilder)
    //    //{
    //    //    // ... 
    //    //    return true;
    //    //}
    //}

    //public readonly record struct ReadonlyCar
    //{

    //}
    //public record struct Car(string Brand, string Model);

    public struct CarAsStruct
    {
        //public string Brand { get; init; }
        public string Brand { get; set; }
        public string Model { get; init; }
    }

    //public record class CarAsClass
    //{
    //    public CarAsClass(string brand, string model)
    //    {
    //        this.Brand = brand;
    //        this.Model = model;
    //    }

    //    public string Brand { get; }
    //    public string Model { get; }
    //}


    /*public record struct CarAsStruct
    {
        public CarAsStruct(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }

        public string Brand { get; }
        public string Model { get; }
    }
    */

    public record Vehicle
    {
        public int WheelCount { get; init; }
        public int DoorCount { get; init; }

        //protected virtual bool PrintMembers(StringBuilder builder)
        //{
        //    //...  
        //    return true;
        //}

        public sealed override string ToString()
        {
            return base.ToString();
        }

    }

    //public record Car2 : Vehicle
    //{
    //    public string Brand { get; init; }
    //    public string Model { get; init; }

    //    protected override bool PrintMembers(StringBuilder builder)
    //    {
    //        //...
    //        return true;
    //    }
    //}
}
