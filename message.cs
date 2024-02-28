using System.ComponentModel.DataAnnotations;

namespace geo
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? City { get; set; }

        public string? Locality { get; set; }

        public string? Content { get; set; }

        public DateTime Time { get; set; }
    }
}