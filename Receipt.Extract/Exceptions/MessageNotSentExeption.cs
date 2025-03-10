namespace Receipt.Extract.Exceptions
{
    public class MessageNotSentExeption : Exception
    {
        private new const string Message = "Message not sent.";

        public MessageNotSentExeption() : base(Message)
        {
        }
    }
}
