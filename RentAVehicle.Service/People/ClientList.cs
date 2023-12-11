

using RentAVehicle.Service.VehicleInformation;

namespace RentAVehicle.Service.People
{
    public class ClientList
    {
        public static List<Client> Generate()
        {
            List<Client> clientList = new List<Client>();
            Client client;

            client = new Client("Ana Carolina", "71991562955", "carol@gmail.com");
            clientList.Add(client);
            client = new Client("Luis Augusto", "71991534874", "luis@gmail.com");
            clientList.Add(client);
            client = new Client("Mara", "7198559874", "mara@gmail.com");
            clientList.Add(client);

            return clientList;
        }

        public static void PrintClients(List<Client> clientsList)
        {
            Console.WriteLine("\n===== Clientes =====");

            foreach (Client client in clientsList)
            {
                    Console.WriteLine(client.ToString());
            }
        }
    }
}
