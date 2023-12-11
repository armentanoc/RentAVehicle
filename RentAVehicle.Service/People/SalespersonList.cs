
namespace RentAVehicle.Service.People

{
    public class SalespersonList
    {
        public static List<Salesperson> Generate()
        {
            List<Salesperson> salespersonList = new List<Salesperson>();
            Salesperson salesperson;

            salesperson = new Salesperson("Ingryd", "71991562955", "ingryd@gmail.com");
            salespersonList.Add(salesperson);
            salesperson = new Salesperson("Nanci", "71991456532", "nanci@gmail.com");
            salespersonList.Add(salesperson);
            salesperson = new Salesperson("Alldrea", "7192456789", "alldrea@gmail.com");
            salespersonList.Add(salesperson);

            return salespersonList;
        }

        public static void PrintSalespersons(List<Salesperson> salespersonsList)
        {
            Console.WriteLine("\n===== Vendedores =====");

            foreach (Salesperson salesperson in salespersonsList)
            {
                Console.WriteLine(salesperson.ToString());
            }
        }
    }
}
