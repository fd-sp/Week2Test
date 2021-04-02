using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Test.Entities.Movements
{
    public class Movement
    {
        public double Amount { get; set; }
        public DateTime MovementDate { get; private set; } = DateTime.Now;

        public Movement() { }
        public Movement(double amount)
        {
            Amount = amount;
        }

        public override string ToString()
        {
            return $"-In Date: {MovementDate.ToShortDateString()}\n" +
                $"-At Time: {MovementDate.ToShortTimeString()}\n" +
                $"-Amount: {Amount}";
        }

    }
}
