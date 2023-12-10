namespace RentAVehicle.Service
{
    public class IdGenerator
    {
        public static string Make()
        {
            return DateTime.Now.GetHashCode().ToString();
        }
    }
}