using System;

namespace Domain.Exceptions
{
    public class NotAllowedToInsertClassroomException : Exception
    {
        public NotAllowedToInsertClassroomException(string message) : base(message)
        {
        }
    }
}