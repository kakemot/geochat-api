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
                            string con = "Server=34.140.79.76;Database=geochatdb;User Id=sqlserver;Password=kakemot1;";
                optionsBuilder.UseSqlServer(con);
            }
        }
    }
}
