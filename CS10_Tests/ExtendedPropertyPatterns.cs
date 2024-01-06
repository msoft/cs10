using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS10_Tests2;

public class Vehicle
{
    public string Name;
    public int PassengerCount;
    public Engine Engine;
}
public class Engine
{
    public string EngineType; 
    public int Horsepower; 
}

//public class Car : Vehicle
//{
//    public int Power;

//    public Car(string name, int passengerCount, int power) :
//      base(name, passengerCount)
//    {
//        this.Power = power;
//    }
//}

//public class Motobike : Vehicle
//{
//    public int Displacement;

//    public Motobike(string name, int passengerCount, int displacement) :
//      base(name, passengerCount)
//    {
//        this.Displacement = displacement;
//    }
//}


internal class ExtendedPropertyPatterns
{
    public void RunMe()
    {
        var fordMustang = new Vehicle { Name = "Ford Mustang", PassengerCount = 4, Engine = new Engine { EngineType = "V8", Horsepower = 480 } };
        var renault4l = new Vehicle { Name = "Renault 4L", PassengerCount = 4, Engine  = new Engine { EngineType = "Straight-four", Horsepower = 27 } };

        var vehicle = fordMustang;
        //string engineSize = string.Empty;
        //if (vehicle.Name == "Ford Mustang")
        //    engineSize = "Big engine";
        //else if (vehicle.Name == "Renault 4L")
        //    engineSize = "Little engine";

        //string engineSize = vehicle switch
        //{
        //    Vehicle { Name: "Ford Mustang" } => "Big engine",
        //    Vehicle { Name: "Renault 4L" } => "Little engine",
        //    _ => "No matches"
        //};

        //if (vehicle is Vehicle { Engine: { EngineType: "V8" } })
        //{
        //    Console.WriteLine("Big engine");
        //}
        //else
        //{
        //    Console.WriteLine("Little engine");
        //}

        //string engineSize = vehicle switch
        //{
        //    Vehicle { Engine: { EngineType: "V8" } } => "Big engine",
        //    Vehicle { Engine: { EngineType: "Straight-four" } } => "Little engine",
        //    _ => "No matches"
        //};



        string engineSize = vehicle switch
        {
            Vehicle { Engine.EngineType: "V8" } => "Big engine",
            Vehicle { Engine.EngineType: "Straight-four" } => "Little engine",
            _ => "No matches"
        };


        if (vehicle is Vehicle { Engine.EngineType:"V8" })
        {
            Console.WriteLine("Big engine");
        }
        else
        {
            Console.WriteLine("Little engine");
        }
    }
}




