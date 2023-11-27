using Pa.Backend.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pa.Backend.Models
{
    public class MetricDbModel
    {
        public Guid id { get; set; }

        [ForeignKey("image_id")]
        public Guid image_id { get; set; }

        public MultiSpectralEnum index_type { get; set; }
        public float healthy_percent { get; set; }
        public float unhealthy_percent { get; set; }
    }
}