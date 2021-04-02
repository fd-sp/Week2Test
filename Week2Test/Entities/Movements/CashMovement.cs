using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Test.Entities.Movements
{
    class CashMovement : MovementDecorator
    {
        public string Performer { get; set; }

        public CashMovement(Movement mov, string performer) : base(mov)
        {
            Performer = performer;
            base.Amount = mov.Amount;
        }

        public override string ToString()
        {
            return $"- CASH MOVEMENT -\n" +
                $"-Performer: {Performer}\n" +
                base.ToString();
        }
    }
}
