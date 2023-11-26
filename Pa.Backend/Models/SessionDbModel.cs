namespace Pa.Backend.Models
{
    public class SessionDbModel
    {
        public Guid id { get; set; }
        public string? sessionName { get; set; }

        public float healthyPercentage { get; set; }

        public float unhealthyPercentage { get; set; }

        public DateTime dtCreated { get; set; }

        public DateTime lstModified { get; set; }
    }

}