using System.ComponentModel.DataAnnotations;

namespace EmailNotification.DTO
{
    public class EmailDto
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        public List<string> CC { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Importance { get; set; }
        public string Content { get; set; }
    }
}
