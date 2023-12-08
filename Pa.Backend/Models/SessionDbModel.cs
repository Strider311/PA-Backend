namespace Pa.Backend.Models
{
    public class SessionDbModel
    {
        public Guid id { get; set; }
        public string? session_name { get; set; }

        public float healthy_percent { get; set; }

        public float unhealthy_percent { get; set; }

        public DateTime dt_created { get; set; }

        public DateTime lst_modified { get; set; }

        public int number_of_images { get; set; }

        public string? path { get; set; }
    }
}