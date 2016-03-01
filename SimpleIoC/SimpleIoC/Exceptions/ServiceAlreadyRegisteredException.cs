using System;
using System.Runtime.Serialization;

namespace SimpleIoC.Exceptions
{
    public class ServiceAlreadyRegisteredException : Exception
    {
        public ServiceAlreadyRegisteredException()
        {
        }

        public ServiceAlreadyRegisteredException(String message)
            : base(message)
        {
        }

        public ServiceAlreadyRegisteredException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ServiceAlreadyRegisteredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
