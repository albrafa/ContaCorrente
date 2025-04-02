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
            string[] transactionsHistory = new string[100];
            int userTransactions = 0;


            // saldo em conta [x]
            double userBalance = 1000;
            double moneyTransfer = 0;


            // numero da conta [x]

            int accountNumberOne = 10;
            int accountNumberTwo = 30;

            Console.Write("Digite o número da conta: ");
            int userLogin = Convert.ToInt32(Console.ReadLine());



            //menu [x]
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

            else if (opcao == 3)
            {
                Console.Write("Informe o valor que deseja sacar: ");
                double accountWithdrawals = Convert.ToDouble(Console.ReadLine());

                if (accountWithdrawals > userBalance)
                {
                    Console.WriteLine($"Transação não efetuada. Não é permitido saque acima do valor depositado em conta. Seu saldo atual é de R${userBalance}.");
                    
                }
                else
                {
                    userBalance = userBalance - accountWithdrawals;
                    Console.WriteLine($"Transação realizada. Seu saldo atual é de R${userBalance}");
                }
            }

            else if (opcao == 4)
            {
                Console.Write($"Deposite o valor que deseja transferir: ");
                if (moneyTransfer > userBalance)
                {
                    Console.WriteLine($"Não é possível realizar transferências com valores acima do saldo atual. Por favor, informe um novo valor para transferência.");

                }
                else
                {

                }
            }

            else if (opcao == 5)
            {
                Console.WriteLine("Histórico de transações: ");
                if (userTransactions == 0)
                {
                    Console.WriteLine("Nenhuma operação realizada no momento.");
                }

                else
                {
                    for (int i = 0; i < userTransactions; i++)
                    {
                        Console.WriteLine("HISTÓRICO DE TRANSAÇÕES: ");
                        Console.WriteLine(transactionsHistory[i]);

                    }
                }
            }


                Console.ReadLine();
        }
    }
}
