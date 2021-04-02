using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Test.Entities.Movements
{
    class TransfertMovement : MovementDecorator
    {
        public string SourceBank { get; set; }
        public string DestinationBank { get; set; }

        public TransfertMovement(Movement mov, string source, string dest) : base(mov)
        {
            SourceBank = source;
            DestinationBank = dest;
            base.Amount = mov.Amount;
        }

        public override string ToString()
        {
            return $"- TRANSFERT MOVEMENT -\n" +
                $"-From the institute: {SourceBank}\n" +
                $"-To the institute: {DestinationBank}\n" +
                base.ToString();
        }
    }
}
