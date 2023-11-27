namespace Pa.Backend.Contracts
{
    public record GetSessionMetricResponse
    {
        public float TotalHealthyPercent { get; set; }
        public float TotalUnhealthyPercent { get; set; }
        public DateTime DateCreated { get; set; }
    }
}