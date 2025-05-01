namespace Common.Exceptions
{
    public class BadRequestException:Exception
    {
        public string Details { get; private set; }

        public BadRequestException(string message, string details):base(message)
        {
            Details = details;
        }
    }
}
