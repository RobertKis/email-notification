using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmailNotification.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public int Importance { get; set; }
        public string Content { get; set; }
    }

    public class EmailDbContext : DbContext
    {
        public EmailDbContext(DbContextOptions<EmailDbContext> options): base(options)
        {
        }

        public DbSet<Email> Emails { get; set; }
    }
}