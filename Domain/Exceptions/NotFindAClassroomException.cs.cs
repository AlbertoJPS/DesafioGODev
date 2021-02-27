using System;

namespace Domain.Exceptions
{
    public class NotFindAClassroomException : Exception
    {
        public NotFindAClassroomException(string message) : base(message)
        {
        }
    }
}