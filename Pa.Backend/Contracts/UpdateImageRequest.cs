namespace Pa.Backend.Contracts
{
    public record UpdateImageRequest
    {
        public bool is_processed { get; set; }
        public bool is_analyzed { get; set; }
    }
}