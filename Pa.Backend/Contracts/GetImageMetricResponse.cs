namespace Pa.Backend.Contracts
{
    public record GetImageMetricResponse
    {
        public Guid id { get; set; }
        public string file_name { get; set; }
        public float healthy_percent { get; set; }
        public float unhealthy_percent { get; set; }
    }
}