namespace _01.Vehicles.Contracts
{
    public interface IBus : IVehicle
    {
        string Drive(double distance, double fuelConsumtion);
    }
}
