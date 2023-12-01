using System;

namespace P03.NeedForSpeed3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] carsData = Console.ReadLine().Split("|").ToArray();
                string model = carsData[0];
                int mileage = int.Parse(carsData[1]);
                int fuel = int.Parse(carsData[2]);
                Car car = new Car(model, mileage, fuel);
                cars.Add(car);
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] instructions = input.Split(" : ");
                string command = instructions[0];
                string model = instructions[1];
                
                if (command == "Drive")
                {
                    int distance = int.Parse(instructions[2]);
                    int fuel = int.Parse((instructions[3]));
                    Car carFound = cars.FirstOrDefault(x => x.Model == model);

                    if (carFound.Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                        continue;
                    }
                    else
                    {
                        carFound.Fuel -= fuel;
                        carFound.Mileage += distance;
                        Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }

                    if (carFound.Mileage >= 100000)
                    {
                        cars.Remove(carFound);
                        Console.WriteLine($"Time to sell the {model}!");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse((instructions[2]));
                    Car carFound = cars.FirstOrDefault(x => x.Model == model);

                    int initialFuel = carFound.Fuel;
                    carFound.Fuel += fuel;
                    if (carFound.Fuel > 75)
                    {
                        carFound.Fuel = 75;
                        Console.WriteLine($"{model} refueled with {75 - initialFuel} liters");
                    }
                    else
                    {
                        Console.WriteLine($"{model} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    int kilometers = int.Parse((instructions[2]));
                    Car carFound = cars.FirstOrDefault(x => x.Model == model);
                    carFound.Mileage -= kilometers;
                    if (carFound.Mileage < 10000)
                    {
                        carFound.Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{model} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}