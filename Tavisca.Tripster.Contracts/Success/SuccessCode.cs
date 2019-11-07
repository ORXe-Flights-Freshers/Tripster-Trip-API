using System.Net;

namespace Tavisca.Tripster.Contracts
{
    public class SuccessCode
    {

        public const int Accepted = (int)HttpStatusCode.Accepted;
        public const int Created = (int)HttpStatusCode.Created;
        public const int NoResponse = (int)HttpStatusCode.NoContent;

    }
}