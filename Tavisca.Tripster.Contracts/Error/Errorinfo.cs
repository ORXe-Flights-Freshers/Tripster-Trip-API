namespace Tavisca.Tripster.Contracts
{
    public class Errorinfo
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public Errorinfo(int errorCode, string ErrorMessages )
        {
            ErrorCode = errorCode;
            ErrorMessage = ErrorMessages;
        }
    }
}