
namespace RentAVehicle.Service.People
{
    public class ClientList
    {
            public static List<Client> Generate()
            {
            List<Client> clientList = new List<Client>();
            Client client;
            
            client = new Client("Ana Carolina", "71991562955", "carol@gmail.com");
            client = new Client("Luis Augusto", "71991534874", "luis@gmail.com");
            client = new Client("Mara", "7198559874", "mara@gmail.com");

            return clientList;
            }
        }
    }
