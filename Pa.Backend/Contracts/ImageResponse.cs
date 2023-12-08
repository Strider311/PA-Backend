namespace Pa.Backend.Contracts
{
    public record ImageResponse
    {
        public FileStream Image { get; set; }
    }
}