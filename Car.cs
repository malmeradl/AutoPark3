class Car
{
    public string LicensePlate { set; get; }
    public string Color { set; get; }
    public string OwnerName { set; get; }
    public bool IsParked { set; get; }
    public int ParkingSlot { get; set; }


    public Car(string myLicensePlate, string myColor, string myOwnerName)
    {
        LicensePlate = myLicensePlate;
        Color = myColor;
        OwnerName = myOwnerName;
        IsParked = false;
        ParkingSlot = 0;
    }

    public Car() { }

    public void inputCarByKeybord()
    {
        Console.Write("Input LicensePlate: ");
        LicensePlate = Console.ReadLine();
        Console.Write("Input color: ");
        Color = Console.ReadLine();
        Console.Write("Input OwnerName: ");
        OwnerName = Console.ReadLine();
        IsParked = false;
        ParkingSlot = 0;
    }


    public override string ToString()
    {
        return $"\nLicensePlate: {LicensePlate}, Color: {Color}, OwnerName: {OwnerName}, {(IsParked ? "is parked" : "is not parked")}";
    }
}