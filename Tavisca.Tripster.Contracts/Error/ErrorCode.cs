using System.Net;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Tripster.Contracts
{
    public class ErrorCode
    {
        public const int InternalServerError = 500;
       public const int BadRequest = (int)HttpStatusCode.BadRequest;
        public const int NotFound = (int)HttpStatusCode.NotFound;
        public const int NoContent = (int)HttpStatusCode.NoContent;

    }
}
