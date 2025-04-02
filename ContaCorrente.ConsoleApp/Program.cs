using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Threading.Channels;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string transactionsHistory;

            // numero da conta [x]
            Console.Write("Digite o número da conta: ");
            int userLogin = Convert.ToInt32(Console.ReadLine());

            // saldo em conta []
            double userBalance = 1000;

            double userTransactions;
            double accountWithdrawwals;
            

            double negativeBalanceLimit;


            //menu
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Banco Brantander Econômica do Brasil");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Digite a operação desejada:");
            Console.WriteLine("");
            Console.WriteLine("1 - Ver saldo");
            Console.WriteLine("2 - Realizar depósito");
            Console.WriteLine("3 - Saque");
            Console.WriteLine("4 - Transferência entre contas");
            Console.WriteLine("5 - Histórico de transações");
            Console.WriteLine();

            int opcao = Convert.ToInt32(Console.ReadLine());

            if (opcao == 1)
            {
                Console.WriteLine($"Seu saldo atual é de R${userBalance}");
                
            }
            else if (opcao == 2)
            {
                Console.Write("Digite o valor que deseja depositar: ");
                double accountDeposits = Convert.ToDouble(Console.ReadLine());

                userBalance = userBalance + accountDeposits;

                Console.WriteLine($"Depósito realizado. Seu saldo atual é de R${userBalance}");

            }


                Console.ReadLine();
        }
    }
}
