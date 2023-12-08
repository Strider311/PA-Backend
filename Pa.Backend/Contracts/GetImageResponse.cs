namespace Pa.Backend.Contracts
{
    public record GetImageResponse
    {
        public Guid id { get; set; }
        public bool is_processed { get; set; }
        public bool is_analyzed { get; set; }
        public string image_name { get; set; }

        public string image_rgb_path { get; set; }
        public List<GetMetricsRequest> metrics { get; set; }
    }
}