namespace Pa.Backend.Contracts
{
    public record GetImageResponse
    {
        public Guid id { get; set; }
        public bool is_processed { get; set; }
        public bool is_analyzed { get; set; }
        public string image_name { get; set; }
        public List<CreateMetricsRequest> metrics { get; set; }
    }
}