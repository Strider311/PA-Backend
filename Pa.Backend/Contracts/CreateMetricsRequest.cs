using Pa.Backend.Enum;

namespace Pa.Backend.Contracts
{
    public record CreateMetricsRequest
    {
        public string index { get; set; }
        public float healthy_percent { get; set; }
        public float unhealthy_percent { get; set; }
        public string image_path { get; set; }
    }
}