using System;
using System.Runtime.Serialization;

namespace SimpleIoC.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException()
        {
        }

        public ServiceNotFoundException(String message)
            : base(message)
        {
        }

        public ServiceNotFoundException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ServiceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
