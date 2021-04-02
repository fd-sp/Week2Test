using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Test.Entities.Movements
{
    class CreditCardMovement : MovementDecorator
    {
        public Kind Kind { get; set; }
        public string CardNumber { get; set; }

        public CreditCardMovement(Movement mov, Kind kind, string cardNo) : base(mov)
        {
            Kind = kind;
            CardNumber = cardNo;
            base.Amount = mov.Amount;
        }

        public override string ToString()
        {
            return $"- CREDIT CARD MOVEMENT -\n" +
                $"-Kind: {Kind}\n" +
                $"-Card Number: {CardNumber}\n" +
                base.ToString();
        }
    }

    public enum Kind
    {
        AMEX,
        VISA,
        MASTERCARD,
        OTHER
    }
}
