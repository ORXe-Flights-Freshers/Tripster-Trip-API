using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tavisca.Tripster.Contracts.Exceptions
{
    [Serializable]
    public class TripNotFoundException : Exception
    {
        public TripNotFoundException()
        {
        }

        public TripNotFoundException(string message) : base(message)
        {
        }

        public TripNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TripNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
