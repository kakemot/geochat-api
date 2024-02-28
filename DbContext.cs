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
                            string con = "User Id=geochat-415222:europe-west1:geochatdb;Password=kakemot1;Server=34.140.79.76;Database=messages;";
                optionsBuilder.UseSqlServer(con);
            }
        }
    }
}
