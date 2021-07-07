using System;
using System.Runtime.Serialization;

namespace Tavisca.Tripster.Contracts.Exceptions
{
    [Serializable]
    public class StopNotFoundException : Exception
    {
        public StopNotFoundException()
        {
        }

        public StopNotFoundException(string message) : base(message)
        {
        }

        public StopNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StopNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
