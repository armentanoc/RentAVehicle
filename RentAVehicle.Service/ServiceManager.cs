using RentAVehicle.Service.MakeReservation;
using RentAVehicle.Service.People;
using RentAVehicle.Service.ProcessPayments;
using RentAVehicle.Service.VehicleInformation;
using System.Globalization;

internal class ServiceManager
{
    private List<Vehicle> vehiclesList = VehicleList.Generate();
    private List<Client> clientsList = ClientList.Generate();
    private List<Salesperson> salespersonList = SalespersonList.Generate();
    private List<Reservation> reservationsList = ReservationList.Generate();
    private List<Payment> paymentsList = PaymentList.Generate();

    public bool ProcessChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                PrintAvailableVehicles();
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
                VehicleList.PrintUnderMaintenanceVehicles(vehiclesList);
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
                return true;

            default:
                Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                break;
        }

        return false;
    }

    private void ExecutePayment()
    {
        Console.WriteLine("\n===== Processamento de Pagamento =====");
        List<Reservation> notPaidReservations = NotPaidReservations();

        if (notPaidReservations.Count >= 1)
        {
            int reservationIndex = GetIndex("Reservas", notPaidReservations);

            Reservation selectedReservation = notPaidReservations[reservationIndex];

            Payment payment = new Payment(selectedReservation);

            Console.WriteLine($"\nDetalhes do pagamento: {payment}");
            Console.Write("\nQual o método de pagamento? (creditCard, debitCard, cash, pix): ");
            PaymentMethodEnum paymentMethod;

            while (!Enum.TryParse(Console.ReadLine(), true, out paymentMethod))
            {
                Console.WriteLine("Método de pagamento inválido. Digite um método de pagamento válido (creditCard, debitCard, cash, pix).");
            }

            payment.ExecutePayment(selectedReservation.GetStartDate(), paymentMethod);
            paymentsList.Add(payment);
            selectedReservation.SetIsPaid(true);

            Console.WriteLine("\nPagamento executado com sucesso!");
        }
    }

    private List<Reservation> NotPaidReservations()
    {
        return reservationsList.Where(reservation => !reservation.IsPaid).ToList();
    }

    private void CreateReservation()
    {
        Console.WriteLine("\n===== Fazer Reserva =====");

        int salespersonIndex = GetIndex("Vendedores", salespersonList);
        int clientIndex = GetIndex("Clientes", clientsList);

        DateTime startDate = GetStartDate();
        int numberOfDays = GetNumberOfDays();
        DateTime endDate = startDate.AddDays(numberOfDays);

        List<Vehicle> availableVehicles = GetAvailableVehicles(startDate, endDate);

        if (availableVehicles.Count > 0)
        {
            int vehicleIndex = GetIndex("Veículos", availableVehicles);

            Reservation reservation = new Reservation(
                salespersonList[salespersonIndex],
                availableVehicles[vehicleIndex],
                clientsList[clientIndex],
                startDate,
                endDate
            );

            reservationsList.Add(reservation);
            Console.WriteLine($"\nDetalhes da Reserva: {reservation}");
        }
        else
        {
            Console.WriteLine("\nNão há veículos disponíveis para o período informado.");
        }
    }

    private void PrintAvailableVehicles()
    {
        DateTime startDate = GetStartDate();
        int numberOfDays = GetNumberOfDays();
        DateTime endDate = startDate.AddDays(numberOfDays);

        List<Vehicle> availableVehicles = GetAvailableVehicles(startDate, endDate);

        if (availableVehicles.Count > 0)
        {
            Console.WriteLine("\nVeículos disponíveis para o período:");
            foreach (Vehicle vehicle in availableVehicles)
            {
                if (vehicle.GetStatus() != VehicleStatus.UnderMaintenance)
                    Console.WriteLine(vehicle.ToString());
            }
        }
        else
        {
            Console.WriteLine("\nNão há veículos disponíveis para o período informado.");
        }
    }

    private List<Vehicle> GetAvailableVehicles(DateTime startDate, DateTime endDate)
    {
        List<Vehicle> availableVehicles = new List<Vehicle>();

        foreach (Vehicle vehicle in vehiclesList)
        {
            if (!IsOverlappingReservation(startDate, endDate, vehicle) && vehicle.GetStatus() != VehicleStatus.UnderMaintenance)
            {
                availableVehicles.Add(vehicle);
            }
        }

        return availableVehicles;
    }

    private bool IsOverlappingReservation(DateTime startDate, DateTime endDate, Vehicle selectedVehicle)
    {
        foreach (Reservation existingReservation in reservationsList)
        {
            if (existingReservation.GetVehicle() == selectedVehicle)
            {
                if (startDate < existingReservation.GetEndDate() && endDate > existingReservation.GetStartDate())
                {
                    return true;
                }
            }
        }

        return false;
    }

    private int GetIndex<T>(string typeOfList, List<T> specificList)
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

    private int GetNumberOfDays()
    {
        int numberOfDays;

        while (true)
        {
            Console.Write("\nInsira o número de diárias que deseja: ");
            if (int.TryParse(Console.ReadLine(), out numberOfDays) && numberOfDays > 0)
            {
                return numberOfDays;
            }

            Console.WriteLine("Número de diárias inválido. Por favor, insira um inteiro positivo.");
        }
    }

    private DateTime GetStartDate()
    {
        DateTime startDate;

        while (true)
        {
            Console.Write("\nDigite a Data de Início (DD/MM/YYYY): ");
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
}