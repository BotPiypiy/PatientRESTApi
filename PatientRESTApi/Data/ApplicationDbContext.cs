using Microsoft.EntityFrameworkCore;
using PatientRESTApi.Models;

namespace PatientRESTApi.Data
{
    /// <summary>
    /// Local context for DB
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Container of all patients
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Constructor using by default (Not a default constructor)
        /// </summary>
        /// <param name="options">Context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(b =>
            {
                b.OwnsOne(p => p.Name, nb =>
                {
                    nb.OwnsOne(n => n.Given);
                });
            });
        }
    }
}
