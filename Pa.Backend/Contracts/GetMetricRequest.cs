namespace Pa.Backend.Contracts
{
    public record GetMetricsRequest
    {
        public string index { get; set; }
        public float healthy_percent { get; set; }
        public float unhealthy_percent { get; set; }
        public Guid id { get; set; }
    }
}