
namespace RentAVehicle.Service.People

{
    public class SalespersonList
    {
        public static List<Salesperson> Generate()
        {
            List<Salesperson> salespersonList = new List<Salesperson>();
            Salesperson salesperson;

            salesperson = new Salesperson("Ingryd", "71991562955", "ingryd@gmail.com");
            salesperson = new Salesperson("Nanci", "71991456532", "nanci@gmail.com");
            salesperson = new Salesperson("Alldrea", "7192456789", "alldrea@gmail.com");

            return salespersonList;
        }
    }
}
