using System;

class Program
{
    static void Main()
    {
        AutoPark autoPark = new AutoPark();
        autoPark.AddCar(new Car("abc123", "blue", "John"));
        autoPark.AddCar(new Car("xyz789", "red", "Alice"));
        autoPark.AddCar(new Car("def456", "green", "Bob"));

        string choice;

        do
        {
            Console.WriteLine("\n\nSelect operation:");
            Console.WriteLine("1. Add a car");
            Console.WriteLine("2. Delete the car");
            Console.WriteLine("3. Find a car by licensePlate");
            Console.WriteLine("4. Find cars by owner");
            Console.WriteLine("5. Get parked cars");
            Console.WriteLine("6. Get unparked cars");
            Console.WriteLine("7. Find a car by parking slot");
            Console.WriteLine("8. Park the car");
            Console.WriteLine("9. Remove the car from the parking lot");
            Console.WriteLine("0. Exit\n");
            Console.WriteLine("ur choice: \n");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    //добавить машину
                    Car newCar = new Car();
                    newCar.inputCarByKeybord();
                    autoPark.AddCar(newCar);
                    break;

                case "2":
                    //удалить по номеру
                    Console.WriteLine("Input licensePlate of the car, u wanna delete:");
                    string licensePlateToRemove = Console.ReadLine();
                    autoPark.RemoveCar(licensePlateToRemove);
                    break;

                case "3":
                    //найти по номеру
                    Console.WriteLine("Input licensePlate of the car, u wanna find:");
                    string searchLicensePlate = Console.ReadLine();
                    Car? foundCar = autoPark.FindCarByLicensePlate(searchLicensePlate);
                    if (foundCar != null)
                    {
                        Console.WriteLine(foundCar);
                    }
                    else
                    {
                        MyErrorPrinter.PrintUserError("Car not found.");
                    }
                    break;

                case "4":
                    //найти по владельцу
                    Console.WriteLine("Input owners name of the car u wanna find:");
                    string searchOwnerName = Console.ReadLine();
                    List<Car> carsByOwner = autoPark.FindCarsByOwnerName(searchOwnerName);
                    if (carsByOwner.Count > 0)
                    {
                        Console.WriteLine("Found cars:");
                        foreach (var car in carsByOwner)
                        {
                            Console.WriteLine(car);
                        }
                    }
                    else
                    {
                        MyErrorPrinter.PrintUserError("Car not found.");
                    }
                    break;

                case "5":
                    // получение припаркованных машин
                    List<Car> parkedCars = autoPark.GetParkedCars();
                    Console.WriteLine("Parked cars:");
                    foreach (var car in parkedCars)
                    {
                        Console.WriteLine(car);
                    }
                    break;

                case "6":
                    // получение неприпаркованных машин
                    List<Car> unparkedCars = autoPark.GetUnparkedCars();
                    Console.WriteLine("Unparked cars:");
                    foreach (var car in unparkedCars)
                    {
                        Console.WriteLine(car);
                    }
                    break;

                case "7":
                    // поиск машины по парковочному слоту
                    Console.WriteLine("Input parkingSlot:");
                    int parkingSlot = ReadInt();

                    Car? carBySlot = autoPark.GetCarByParkingSlot(parkingSlot);
                    if (carBySlot != null)
                    {
                        Console.WriteLine(carBySlot);
                    }
                    else
                    {
                        MyErrorPrinter.PrintUserError("Car not found.");
                    }

                    break;

                case "8":
                    // припарковать машину
                    Console.WriteLine("Input parkingSlot:");
                    int parkSlot = ReadInt();

                    Console.WriteLine("Input licensePlate of the car u wanna park:");
                    string carLicensePlate = Console.ReadLine();
                    Car? carToPark = autoPark.FindCarByLicensePlate(carLicensePlate);
                    if (carToPark != null)
                    {
                        autoPark.ParkCar(carToPark, parkSlot);
                    }
                    else
                    {
                        MyErrorPrinter.PrintUserError("Car not found.");
                    }

                    break;

                case "9":
                    // убрать машину с парковки
                    Console.WriteLine("Input parkingSlot of the car u wanna unpark:");
                    int unparkSlot = ReadInt();
                    autoPark.UnparkCar(unparkSlot);

                    break;

                case "0":
                    // Выход из программы
                    Console.WriteLine("exit.");
                    break;

                default:
                    MyErrorPrinter.PrintUserError("Uncorrect operation number. Try again.");
                    break;
            }

        } while (choice != "0");
    }
    static int ReadInt()
    {
        int parsedValue;
        while (!int.TryParse(Console.ReadLine(), out parsedValue))
        {
            MyErrorPrinter.PrintUserError("Invalid input. Please enter number.");
        }
        return parsedValue;

    }


}