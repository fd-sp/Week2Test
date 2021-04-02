using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Week2Test.Entities.Movements;

namespace Week2Test.Entities
{
    public class Account<T> : IEnumerable<T> where T : Movement
    {
        private List<T> Movements = new List<T>();
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public double Balance { get; private set; } = 0.00;
        public DateTime LastTransactionDate { get; set; }

        public Account(string accNo, string bank)
        {
            AccountNumber = accNo;
            BankName = bank;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Movements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Account<T> operator +(Account<T> acc, T mov)
        {
            acc.Movements.Add(mov);
            acc.Balance = acc.Balance + mov.Amount;
            acc.LastTransactionDate = mov.MovementDate;
            return acc;
        }

        public static Account<T> operator -(Account<T> acc, T mov)
        {
            acc.Movements.Add(mov);
            acc.Balance = acc.Balance - mov.Amount;
            acc.LastTransactionDate = mov.MovementDate;
            return acc;
        }

        public void Statement()
        {
            Console.WriteLine($"{BankName.ToUpper()}\n" +
                $"- Account number: {AccountNumber}\n" +
                $"- Balance: {Math.Round(Balance, 2)}\n\n" +
                $"- The last movement was :\n" +
                $"\tin date: {LastTransactionDate.ToShortDateString()}\n" +
                $"\tat time: {LastTransactionDate.ToShortTimeString()}\n\n" +
                $"\t***********************************\n" +
                $"\t*                                 *\n" +
                $"\t*\tLIST OF MOVEMENTS\t  *\n" +
                $"\t*                                 *\n" +
                $"\t***********************************\n\n");
            foreach (var item in Movements)
            {
                Console.WriteLine($"{item}\n" +
                    $"********************\n");

            }
        }
    }
}
