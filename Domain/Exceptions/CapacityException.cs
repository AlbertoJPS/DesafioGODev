using System;

namespace Domain.Exceptions
{
    public class CapacityException : Exception
    {
        public CapacityException(string message) : base(message)
        {
        }
    }
}