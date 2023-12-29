class AutoPark
{
    List<Car> cars;
    Dictionary<int, Car> parkedCars;

    public AutoPark()
    {
        cars = new List<Car>();
        parkedCars = new Dictionary<int, Car>();
    }
    public void AddCar(Car car)
    {
        if (!cars.Exists(c => c.LicensePlate == car.LicensePlate))
        {
            cars.Add(car);
        }
        else
        {
            MyErrorPrinter.PrintUserError("A car with this LicensePlate already exists.");
        }
    }


    public void RemoveCar(string licensePlate)
    {
        Car? carToRemove = cars.FirstOrDefault(c => c.LicensePlate == licensePlate);
        if (carToRemove != null)
        {
            if (carToRemove.IsParked)
            {
                parkedCars.Remove(carToRemove.ParkingSlot);
            }
            cars.Remove(carToRemove);
            Console.WriteLine("Okk.");
        }
        else
        {
            MyErrorPrinter.PrintUserError("A car with this license number is not in the list");
        }
    }
    public Car? FindCarByLicensePlate(string licensePlate)
    {
        return cars.FirstOrDefault(c => c.LicensePlate == licensePlate);
    }
    public List<Car> FindCarsByOwnerName(string ownerName)
    {
        return cars.Where(c => c.OwnerName == ownerName).ToList();
    }

    public List<Car> GetParkedCars()
    {
        return cars.Where(c => c.IsParked).ToList();
    }

    public List<Car> GetUnparkedCars()
    {
        return cars.Where(c => !c.IsParked).ToList();
    }

    public Car? GetCarByParkingSlot(int parkingSlot)
    {
        if (parkedCars.ContainsKey(parkingSlot))
        {
            return parkedCars[parkingSlot];
        }
        return null;
    }

    public void ParkCar(Car car, int parkingSlot)
    {
        if (car.IsParked)
        {
            UnparkCar(car.ParkingSlot);
        }
        if (!parkedCars.ContainsKey(parkingSlot))
        {
            car.ParkingSlot = parkingSlot;
            car.IsParked = true;
            parkedCars[parkingSlot] = car;
        }
        else
        {
            MyErrorPrinter.PrintUserError("ParkingSlot is already used.");
        }
    }

    public void UnparkCar(int parkingSlot)
    {
        if (parkedCars.ContainsKey(parkingSlot))
        {
            Car car = parkedCars[parkingSlot];
            car.ParkingSlot = 0;
            car.IsParked = false;
            parkedCars.Remove(parkingSlot);
        }
        else
        {
            MyErrorPrinter.PrintUserError("There is no parked car in this parkingSlot.");
        }
    }

}