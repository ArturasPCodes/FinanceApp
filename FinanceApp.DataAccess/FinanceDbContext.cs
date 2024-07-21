using FinanceApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.DataAccess
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Instrument>()
                .HasMany(i => i.Investments)
                .WithOne(i => i.Instrument)
                .HasForeignKey(i => i.InstrumentId);

            base.OnModelCreating(builder);
        }
    }
}
