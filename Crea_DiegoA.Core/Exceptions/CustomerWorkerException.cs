using System;

namespace Crea_DiegoA.Core.Exceptions
{
    public class CustomerWorkerException : Exception
    {
        public CustomerWorkerException(string message): base(message)
        {
        }
    }
}
