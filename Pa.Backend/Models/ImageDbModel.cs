using System.ComponentModel.DataAnnotations.Schema;

namespace Pa.Backend.Models
{
    public class ImageDbModel
    {
        public Guid id { get; set; }

        [ForeignKey("SessionId")]
        public Guid session_id { get; set; }
        public string? fileName { get; set; }
        public float healthyPercentage { get; set; }
        public float unhealthyPercentage { get; set; }
        public DateTime dtCreated { get; set; }
        public DateTime lstModified { get; set; }
    }

}