using System.ComponentModel.DataAnnotations.Schema;

namespace Pa.Backend.Models
{
    public class ImageDbModel
    {
        public Guid id { get; set; }

        [ForeignKey("SessionId")]
        public Guid session_id { get; set; }

        public string? file_name { get; set; }

        public string? file_path { get; set; }
        public DateTime dt_created { get; set; }
        public DateTime lst_modified { get; set; }
        public bool is_processed { get; set; }
        public bool is_analyzed { get; set; }
    }
}