using System;

namespace Domain.Exceptions
{
    public class NotAllowedToSubscribeStudentsException : Exception
    {
        public NotAllowedToSubscribeStudentsException(string message) : base(message)
        {
        }
    }
}