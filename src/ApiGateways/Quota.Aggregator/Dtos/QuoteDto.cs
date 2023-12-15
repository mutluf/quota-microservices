namespace Quota.Aggregator.Dtos
{
    public class QuoteDto
    {
        public string Content { get; set; }
        public int QuoteId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
