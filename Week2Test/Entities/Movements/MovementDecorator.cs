using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Test.Entities.Movements
{
    public abstract class MovementDecorator : Movement
    {
        public Movement MovementDec { get; set; }
        
        public MovementDecorator(Movement movement)
        {
            MovementDec = movement;
        }
    }
}
