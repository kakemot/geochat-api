using Microsoft.EntityFrameworkCore;
using System;

namespace geo
{
    public class MyDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Specify the connection string for your SQL Server database
                            string con = "Server=10.86.48.3;Database=geochatdb;User Id=sqlserver;Password=kakemot1;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(con);
            }
        }
    }
}
