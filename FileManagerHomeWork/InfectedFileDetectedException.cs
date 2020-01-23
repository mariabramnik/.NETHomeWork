using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerHomeWork
{
    class InfectedFileDetectedException : Exception
    {
 
        public InfectedFileDetectedException(string message) : base(message)
        {
        }


    }
}
