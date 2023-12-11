
namespace RentAVehicle.Service.ProcessPayments
{
    internal class PaymentList
    {
        public static List<Payment> Generate()
        {
          List<Payment> paymentsList = new List<Payment>();
          Payment payment;
          return paymentsList;
         }

            public static void PrintPayments(List<Payment> paymentsList)
            {
                Console.WriteLine("\n===== Pagamentos =====");
                foreach (Payment payment in paymentsList)
                {
                    Console.WriteLine(payment.ToString());
                }
            }
        }
    }