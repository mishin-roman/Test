using Microsoft.EntityFrameworkCore;

namespace TestAyaksRielt.Models

{
    public class RealtorContext : DbContext
{

        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public RealtorContext(DbContextOptions<RealtorContext> options)
        : base(options)
    { }
}
}