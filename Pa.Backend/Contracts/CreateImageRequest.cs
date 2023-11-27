namespace Pa.Backend.Contracts
{
    public record CreateImageRequest
    {
        public string fileName { get; set; }
        public Guid sessionId { get; set; }
    }
}