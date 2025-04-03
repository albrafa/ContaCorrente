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
            string[] transactionsHistoryAccount2 = new string[100];
           
            int userTransactions = 0;
            int userTransactionsAccount2 = 0;


            // saldo em conta [x]
            double userBalance = 1000;
            double moneyTransfer = 0;

            // saldo em conta 2 [x]
            double userBalanceAccount2 = 2000;
            double moneyTransferAccount2 = 0;


            // numero da conta [x]

            int accountNumberOne = 10;
            int accountNumberTwo = 30;

            Console.Write("Digite o número da conta: ");
            int userLogin = Convert.ToInt32(Console.ReadLine());

            if (userLogin == accountNumberOne)
            {                
                int opcao = DisplayMenuAccount1();

                BalanceTranactionsHistoryAccount1(transactionsHistory, ref userBalanceAccount2, userTransactions, ref userBalance, ref moneyTransfer, opcao);
            }         
                        

            if (userLogin == accountNumberTwo)
            {
                int opcao = DisplayMenuAccount2();

                BalanceTransactionsHistoryAccount2(transactionsHistoryAccount2, userTransactionsAccount2, ref userBalanceAccount2, ref moneyTransferAccount2, ref userBalance, opcao);
            }


            Console.ReadLine();
        } 

        private static void BalanceTransactionsHistoryAccount2(string[] transactionsHistoryAccount2, int userTransactionsAccount2, ref double userBalanceAccount2, ref double moneyTransferAccount2, ref double userBalance, int opcao)
        {
            if (opcao == 1)
            {
                Console.WriteLine($"Seu saldo atual é de R${userBalanceAccount2}");

            }
            else if (opcao == 2)
            {
                Console.Write("Digite o valor que deseja depositar: ");
                double accountDepositsAccount2 = Convert.ToDouble(Console.ReadLine());

                userBalanceAccount2 = userBalanceAccount2 + accountDepositsAccount2;

                Console.WriteLine($"Depósito realizado. Seu saldo atual é de R${userBalanceAccount2}");

            }

            else if (opcao == 3)
            {
                Console.Write("Informe o valor que deseja sacar: ");
                double accountWithdrawalsAccount2 = Convert.ToDouble(Console.ReadLine());

                if (accountWithdrawalsAccount2 > userBalanceAccount2)
                {
                    moneyTransferAccount2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Transação não efetuada. Não é permitido saque acima do valor depositado em conta. Seu saldo atual é de R${userBalance}.");
                }
                else
                {
                    userBalanceAccount2 = userBalanceAccount2 - accountWithdrawalsAccount2;
                    Console.WriteLine($"Transação realizada. Seu saldo atual é de R${userBalanceAccount2}");
                }
            }

            else if (opcao == 4)
            {
                Console.Write($"Deposite o valor que deseja transferir: ");
                moneyTransferAccount2 = Convert.ToDouble(Console.ReadLine());

                if (moneyTransferAccount2 > userBalanceAccount2)
                {
                    Console.WriteLine($"Não é possível realizar transferências com valores acima do saldo atual. Por favor, informe um novo valor para transferência.");

                }
                else if (userBalanceAccount2 > moneyTransferAccount2)
                {
                    Console.Write("Informe o valor que deseja depositar na conta número dois: ");

                    moneyTransferAccount2 = Convert.ToDouble(Console.ReadLine());
                    userBalanceAccount2 = userBalanceAccount2 - moneyTransferAccount2;
                    userBalance = userBalance + moneyTransferAccount2;
                    Console.WriteLine();
                    Console.WriteLine($"Transferência entre contas realiaza! Seu saldo atual é de {userBalanceAccount2}.");
                }
            }

            else if (opcao == 5)
            {
                Console.WriteLine("Histórico de transações: ");
                if (userTransactionsAccount2 == 0)
                {
                    Console.WriteLine("Nenhuma operação realizada no momento.");
                }

                else
                {
                    for (int i = 0; i < userTransactionsAccount2; i++)
                    {
                        Console.WriteLine("HISTÓRICO DE TRANSAÇÕES: ");
                        Console.WriteLine(transactionsHistoryAccount2[i]);

                    }
                }
            }
        }

        private static int DisplayMenuAccount2()
        {
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
            return opcao;
        }

        private static void BalanceTranactionsHistoryAccount1(string[] transactionsHistory, ref double userBalanceAccount2, int userTransactions, ref double userBalance, ref double moneyTransfer, int opcao)
        {
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
                moneyTransfer = Convert.ToDouble(Console.ReadLine());

                if (moneyTransfer > userBalance)
                {
                    Console.WriteLine($"Não é possível realizar transferências com valores acima do saldo atual. Por favor, informe um novo valor para transferência.");

                }
                else if (userBalance > moneyTransfer)
                {
                    userBalance = userBalance - moneyTransfer;
                    userBalanceAccount2 = userBalanceAccount2 + moneyTransfer;
                    Console.WriteLine();
                    Console.WriteLine($"Transferência entre contas realiaza! Seu saldo atual é de R${userBalance}.");
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
        }

        private static int DisplayMenuAccount1()
        {
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
            return opcao;
        }
    }
}
