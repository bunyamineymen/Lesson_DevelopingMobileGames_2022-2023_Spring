using System;
namespace ExternalGameProject_Example
{
    public abstract class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }
        public abstract void StartEngine();
    }

    public class BMW : Car
    {
        public float FuelEfficiency { get; set; }
        public override void StartEngine()
        {
            Console.WriteLine("BMW engine started");
        }
    }

    public class Audi : Car
    {
        public override void StartEngine()
        {
            Console.WriteLine("Audi engine started");
        }
    }

    public class CarFactory
    {
        public static Car? CreateCar(string carType)
        {
            Car car;
            // We cannot create an instance of an abstract class. Bottom code will not compile.
            // var testCart = new Car(); 
            switch (carType)
            {
                case "BMW":
                    car = new BMW();
                    break;
                case "Audi":
                    car = new Audi();
                    break;
            }
            return default;
        }
    }

    public static class Program2
    {
        public static void Main()
        {
            Car? car = CarFactory.CreateCar("BMW");
            car?.StartEngine();

            var car2 = CarFactory.CreateCar("Audi");
            car2?.StartEngine();
        }
    }

}