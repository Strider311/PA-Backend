namespace Pa.Backend.Contracts
{
    public record GetSessionResponse
    {
        public string SessionName { get; set; }
        public Guid id { get; set; }
        public int NoOfImages { get; set; }
        public DateTime DateCreated { get; set; }
    }
}