public class Car
{
    public Car(string model, int mileage, int fuel)
    {
        Model = model;
        Mileage = mileage;
        Fuel = fuel;
    }
    public string Model { get; set; }
    public int Mileage { get; set; }
    public int Fuel { get; set; }

    public override string ToString()
    {
        return $"{Model} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
    }
}
