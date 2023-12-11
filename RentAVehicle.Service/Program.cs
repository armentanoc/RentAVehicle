internal class Program
{
    private static ServiceManager serviceManager = new ServiceManager();

    private static void Main(string[] args)
    {
        bool exitProgram = false;

        do
        {
            Console.Clear();
            Console.WriteLine("===== Serviço de Aluguel de Veículos =====\n");
            Console.WriteLine("1. Exibir veículos disponíveis no período");
            Console.WriteLine("2. Fazer uma reserva");
            Console.WriteLine("3. Processar pagamento");
            Console.WriteLine("4. Exibir reservas");
            Console.WriteLine("5. Exibir veículos em manutenção");
            Console.WriteLine("6. Exibir informações dos pagamentos");
            Console.WriteLine("7. Exibir informações dos clientes");
            Console.WriteLine("8. Exibir informações dos vendedores");
            Console.WriteLine("9. Sair");

            Console.Write("\nRegistre sua escolha (1-9): ");
            string choice = Console.ReadLine();

            exitProgram = serviceManager.ProcessChoice(choice);

            if (!exitProgram)
            {
                Console.WriteLine("\nPressione enter para continuar...");
                Console.ReadLine();
            }

        } while (!exitProgram);
    }
}