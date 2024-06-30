
using System.Reflection.Metadata.Ecma335;
using static Program;

class Program
{
    public delegate Car CarFactoryDel(int id, string name);
    public delegate void LogICECarDetailsDel(ICECar car);
    public delegate void LogEVCarDetailsDel(EVCar car);
    public static void Main(string[] args)
    {
        CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;
        Car iceCar = carFactoryDel(1, "Audi");

        carFactoryDel = CarFactory.ReturnEVCar;

        Car evCar = carFactoryDel(2, "Toyota");

        LogICECarDetailsDel logICECarDetailsDel = LogDetails;
        logICECarDetailsDel(iceCar as ICECar);
        LogEVCarDetailsDel logEVCarDetailsDel = LogDetails;
        logEVCarDetailsDel(evCar as EVCar);

        //Func<int, string, Car> iceCarFactory = (id, name) => { return new ICECar { Id = id, Name = name }; };
        //Car iceCar = iceCarFactory(1, "Audi");

        //Func<int,string,Car> evCarFactory = (id, name) => { return new EVCar { Id = id, Name = name }; };
        //Car evCar = evCarFactory(2, "Totota");

        //Action<Car> displayInfo = LogDetails;
        //displayInfo(iceCar as ICECar);
        //displayInfo(evCar as EVCar);

    }

    public static void LogDetails(Car car)
    {
        if(car is ICECar)
        {
            using(var streamWritter = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"ICECarDetails.txt"),true))
            {

                streamWritter.WriteLine($"Object type: {car.GetType()}");
                streamWritter.WriteLine(car.GetCarDetails());
            }
        }
        else if(car is EVCar)
        {
            Console.WriteLine($"Object type: {car.GetType()}");
            Console.WriteLine(car.GetCarDetails());
        }
        else
        {
            throw new ArgumentException("Incorrect Argument type");
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar
            {
                Id = id,
                Name = name,
            };
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar
            {
                Id = id,
                Name = name,
            };
        }
    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name}";
        }
    }
    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }

}