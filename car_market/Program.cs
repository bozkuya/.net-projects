using car_market.Entities;
using car_market.Enums;

class Program
{
    static List<Car> availableCars = new List<Car>()
        {
            new Car("Toyota Corolla", CarType.Sedan),
            new Car("Honda Civic", CarType.Sedan),
            new Car("Ford Focus", CarType.Sedan),
            new Car("Fiat Egea", CarType.Sedan)
        };

    static List<Car> rentedCars = new List<Car>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Car Rental System");
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n1. Rent a car");
            Console.WriteLine("2. Return a car");
            Console.WriteLine("3. List available cars");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RentCar();
                    break;

                case "2":
                    ReturnCar();
                    break;
                case "3":
                    ListAvailableCars();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void RentCar()
    {
        Console.WriteLine("Enter the car you want to rent: ");
        string carToRent = Console.ReadLine();

        Car car = availableCars.FirstOrDefault(c => c.Model.Equals(carToRent, StringComparison.OrdinalIgnoreCase));

        if (car != null)
        {
            car.Rent();
            availableCars.Remove(car);
            rentedCars.Add(car);
            Console.WriteLine("You have rented a " + carToRent);
        }
        else
        {
            Console.WriteLine("Sorry, the selected car is not available.");
        }
    }

    static void ReturnCar()
    {
        Console.WriteLine("Enter the car you want to return: ");
        string carToReturn = Console.ReadLine();

        Car car = rentedCars.FirstOrDefault(c => c.Model.Equals(carToReturn, StringComparison.OrdinalIgnoreCase));

        if (car != null)
        {
            car.Return();
            rentedCars.Remove(car);
            availableCars.Add(car);
            Console.WriteLine("You have returned a " + carToReturn);
        }
        else
        {
            Console.WriteLine("Sorry, you did not rent this car from us.");
        }
    }

    static void ListAvailableCars()
    {
        Console.WriteLine("Available cars:");
        foreach (var car in availableCars)
        {
            Console.WriteLine(car.Model);
        }
    }
}