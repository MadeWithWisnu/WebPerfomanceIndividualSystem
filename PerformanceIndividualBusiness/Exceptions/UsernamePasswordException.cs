using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceIndividualBusiness.Exceptions
{
    public class UsernamePasswordException : Exception
    {
        public UsernamePasswordException(string? message) : base(message)
        {
        }
    }
}
