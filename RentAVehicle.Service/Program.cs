
using RentAVehicle.Service.VehicleInformation;
using RentAVehicle.Service.ProcessPayments;
using RentAVehicle.Service.People;
using RentAVehicle.Service.MakeReservation;
using System.Globalization;

namespace RentAVehicle.Service
{
    internal class Program
    { 
        static List<Vehicle> vehiclesList = VehicleList.Generate();
        static List<Client> clientsList = ClientList.Generate();
        static List<Salesperson> salespersonList = SalespersonList.Generate();
        static List<Reservation> reservationsList = ReservationList.Generate();
        static List<Payment> paymentsList = PaymentList.Generate();
        static void Main(string[] args)
        {

            bool exitProgram = false;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Serviço de Aluguel de Veículos =====\n");
                Console.WriteLine("1. Exibir veículos disponíveis");
                Console.WriteLine("2. Fazer uma reserva");
                Console.WriteLine("3. Processar pagamento");
                Console.WriteLine("4. Exibir reservas");
                Console.WriteLine("5. Exibir veículos alugados");
                Console.WriteLine("6. Exibir informações dos pagamentos");
                Console.WriteLine("7. Exibir informações dos clientes");
                Console.WriteLine("8. Exibir informações dos vendedores");
                Console.WriteLine("9. Sair");

                Console.Write("\nRegistre sua escolha (1-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        VehicleList.PrintAvailableVehicles(vehiclesList);
                        break;

                    case "2":
                        CreateReservation();
                        break;

                    case "3":
                        ExecutePayment();
                        break;

                    case "4":
                        ReservationList.PrintReservations(reservationsList);
                        break;

                    case "5":
                        VehicleList.PrintRentedVehicles(vehiclesList);
                        break;

                    case "6":
                        PaymentList.PrintPayments(paymentsList);
                        break;

                    case "7":
                        ClientList.PrintClients(clientsList);
                        break;

                    case "8":
                        SalespersonList.PrintSalespersons(salespersonList);
                        break;

                    case "9":
                        exitProgram = true;
                        break;

                    default:
                        Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                        break;
                }

                if (!exitProgram)
                {
                    Console.WriteLine("\nPressione enter para continuar...");
                    Console.ReadLine();
                }

            } while (!exitProgram);
        }

        private static void ExecutePayment()
        {
            Console.WriteLine("\n===== Processamento de Pagamento =====");
            int reservationIndex = GetIndex("Reservas", reservationsList);

            Reservation selectedReservation = reservationsList[reservationIndex];

            Payment payment = new Payment(selectedReservation);

            Console.WriteLine("\nDetalhes do pagamento: " + payment.ToString());

            Console.Write("\nQual o método de pagamento? (creditCard, debitCard, cash, pix): ");
            PaymentMethodEnum paymentMethod;

            while (!Enum.TryParse(Console.ReadLine(), true, out paymentMethod))
            {
                Console.WriteLine("Método de pagamento inválido. Digite um método de pagamento válido (creditCard, debitCard, cash, pix).");
            }

            payment.ExecutePayment(selectedReservation.getStartDate(), paymentMethod);
            paymentsList.Add(payment);

            Console.WriteLine("\nPagamento executado com sucesso!");
        }
        private static void CreateReservation()
        {
            Console.WriteLine("\n===== Criar Reserva =====");

            int salespersonIndex = GetIndex("Vendedores", salespersonList);
            int clientIndex = GetIndex("Clientes", clientsList);
            int vehicleIndex = GetIndex("Veículos", vehiclesList);

            DateTime startDate = GetStartDate();
            int numberOfDays = GetNumberOfDays();
            DateTime endDate = startDate.AddDays(numberOfDays);

            Reservation reservation = new Reservation(
                salespersonList[salespersonIndex],
                vehiclesList[vehicleIndex],
                clientsList[clientIndex],
                startDate,
                endDate
            );

            reservationsList.Add(reservation);
            Console.WriteLine("\nDetalhes da reserva: " + reservation.ToString());
        }
        private static DateTime GetStartDate()
        {
            DateTime startDate;

            while (true)
            {
                Console.Write("Digite a Data de Início (DD/MM/YYYY): ");
                string input = Console.ReadLine();

                input = input.Replace("/", "").Replace("-", "");

                if (DateTime.TryParseExact(input, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate)
                    && startDate >= DateTime.Today
                    && startDate <= DateTime.Today.AddYears(1))
                {
                    return startDate;
                }

                Console.WriteLine("Data inválida. Por favor, digite uma data válida entre hoje e um ano a partir de agora.");
            }
        }
        private static int GetNumberOfDays()
        {
            int numberOfDays;

            while (true)
            {
                Console.Write("Insira o número de diárias que deseja: ");
                if (int.TryParse(Console.ReadLine(), out numberOfDays) && numberOfDays > 0)
                {
                    return numberOfDays;
                }

                Console.WriteLine("Número de diárias inválido. Por favor, insira um inteiro positivo.");
            }
        }
        private static int GetIndex<T>(string typeOfList, List<T> specificList)
        {
            int listSize = specificList.Count;
            int maxIndex = listSize - 1;

            Console.WriteLine($"\n{typeOfList} disponíveis:");

            for (int i = 0; i < listSize; i++)
            {
                Console.WriteLine($"{i} - {specificList[i].ToString()}");
            }

            Console.Write($"Digite o índice (0-{maxIndex}): ");

            int objectIndex;
            while (!int.TryParse(Console.ReadLine(), out objectIndex) || objectIndex < 0 || objectIndex > maxIndex)
            {
                Console.WriteLine($"Erro. Por favor digite um índice válido (0 - {maxIndex}).");
            }
            return objectIndex;
        }
    }
}
