using Pa.Backend.Enum;

namespace Pa.Backend.Contracts
{
    public record CreateMetricsRequest
    {
        public MultiSpectralEnum index_Type { get; set; }
        public float healthy_percent { get; set; }
        public float unhealthy_percent { get; set; }
    }
}