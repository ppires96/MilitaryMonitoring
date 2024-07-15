using Microsoft.EntityFrameworkCore;

namespace MilitaryMonitoring.Models
{
    public class TrainingContext : DbContext
    {
        public virtual DbSet<Soldier> Soldiers { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Should store this connection string safely, depending on the service we use to manage the code.
            // Maybe a key vault. Maybe the environment variables, app settings..
            // For now I just wrote it here directly to conenct to my SQL Server Management Studio.
            string databaseConnectionString = "Data Source=DESKTOP-AHV3F8Q\\SQLEXPRESS;Initial Catalog=Military;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False";
            optionsBuilder.UseSqlServer(databaseConnectionString);
        }
    }

}
