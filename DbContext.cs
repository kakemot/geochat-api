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
                            string con = "User Id=p28978082619-v5bgt6@gcp-sa-cloud-sql.iam.gserviceaccount.com;Password=kakemot1;Server=geochat-415222:europe-west1:geochatdb;Database=messages;";
                optionsBuilder.UseSqlServer(con);
            }
        }
    }
}
