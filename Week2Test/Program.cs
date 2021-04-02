using System;
using Week2Test.Entities.Movements;
using Week2Test.Entities;
using System.Collections.Generic;
using System.Threading;

namespace Week2Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int bancomatNum = rand.Next(11, 9999);

            Account<Movement> myBankAccount = new Account<Movement>("00001AYH182", "Morgan Stanley");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("BENVENUTO/A AL BANCOMAT MORGAN STANLEY N. 00C" + bancomatNum);
                Thread.Sleep(1000);
                Console.WriteLine("Scegli che tipo di movimento vuole effettuare:");
                Console.WriteLine("-1 Cash Movement\n" +
                    "-2 Transfert Movement\n" +
                    "-3 Credit Card Movement");
                int x = int.Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Per favore inserisca l'ammontare:");
                        double cashAmount = double.Parse(Console.ReadLine());
                        Console.WriteLine("Per favore inserisca se è un movimento positivo o negativo  +/-:");
                        string cashSign = Console.ReadLine();

                        Console.WriteLine("Per favore inserisca chi effettua l'operazione:");
                        string performer = Console.ReadLine();
                        CashMovement cash = new CashMovement(new Movement(cashAmount), performer);

                        if (cashSign.Equals("+"))
                        {
                            myBankAccount += cash;
                        }else if(cashSign.Equals("-"))
                        {
                           
                            myBankAccount -= cash;
                            cash.Amount *= -1.0;
                        }
                        break;

                    case 2:
                        Console.WriteLine("Per favore inserisca l'ammontare:");
                        double transfertAmount = double.Parse(Console.ReadLine());
                        Console.WriteLine("Per favore inserisca se è un movimento positivo o negativo  +/-:");
                        string transfertSign = Console.ReadLine();

                        Console.WriteLine("Per favore inserisca l'istituto emittente:");
                        string source = Console.ReadLine();
                        Console.WriteLine("Per favore inserisca l'istituto destinatario:");
                        string dest = Console.ReadLine();
                        TransfertMovement transfert = new TransfertMovement(new Movement(transfertAmount), source, dest);

                        if (transfertSign.Equals("+"))
                        {
                            myBankAccount += transfert;
                        }
                        else if (transfertSign.Equals("-"))
                        {
                            myBankAccount -= transfert;
                            transfert.Amount *= -1.0;
                        }
                        break;

                    case 3:
                        Console.WriteLine("Per favore inserisca l'ammontare:");
                        double cardAmount = double.Parse(Console.ReadLine());
                        Console.WriteLine("Per favore inserisca se è un movimento positivo o negativo  +/-:");
                        string cardSign = Console.ReadLine();

                        Console.WriteLine("Per favore inserisca l'emittente della carta scegliendo tra:");
                        Console.WriteLine("-AMEX\n" +
                            "-VISA\n" +
                            "-MASTER CARD\n" +
                            "-OTHER");
                        Kind kind;
                        try
                        {
                            kind = (Kind)Enum.Parse(typeof(Kind), Console.ReadLine().Trim().Replace(" ",""), true);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ci dispiace, ma non è stato possibile individuare l'istituto emittente;\n" +
                                "per favore ripeta la procedura digitando correttamente il nome dell'emittente\n");
                            Thread.Sleep(2500);
                            goto case 3;
                        }
                        Console.WriteLine("Per favore inserisca il numero di carta:");
                        string cardNo = Console.ReadLine();
                        CreditCardMovement creditCard = new CreditCardMovement(new Movement(cardAmount), kind, cardNo);

                        if (cardSign.Equals("+"))
                        {
                            myBankAccount += creditCard;
                        } 
                        else if (cardSign.Equals("-"))
                        {
                            myBankAccount -= creditCard;
                            creditCard.Amount *= -1.0;
                        }
                        break;
                    default:
                        Console.WriteLine("Per favore inserisca un numero corrispondente al tipo di operazione");
                        break;
                }

                Console.WriteLine("Se vuole inserire un'altro movimento premi invio altrimenti prema Q");
                if (Console.ReadLine().ToLower().Equals("q"))
                    exit = true;
                Console.Clear();
            }

            Console.WriteLine("Vuole stampare il dettaglio del suo conto con annessa lista dei movimenti?   Y/N");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.Clear();
                myBankAccount.Statement();
            }
        }
    }
}
