using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.ExpressionSolver
{
    public class InvalidLinearEquation : Exception
    {
        public InvalidLinearEquation() : base()
        {
            
        }

        public InvalidLinearEquation(string message) : base(message)
        {
            
        }

        
    }
}
