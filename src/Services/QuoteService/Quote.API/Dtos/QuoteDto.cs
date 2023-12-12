namespace Quote.API.Dtos
{
    public class QuoteDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
