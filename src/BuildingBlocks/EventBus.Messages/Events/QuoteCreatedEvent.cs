namespace EventBus.Messages.Events
{
    public class QuoteCreatedEvent
    {
        public int QuoteId { get; set; }
        public string Username { get; set; }
    }
}
