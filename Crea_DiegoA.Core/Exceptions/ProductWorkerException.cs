using System;

namespace Crea_DiegoA.Core.Exceptions
{
    public class ProductWorkerException : Exception
    {
        public ProductWorkerException(string message): base(message)
        {
        }
    }
}
