using backend.Models;
using backend.Models.Table;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ms_user> ms_user { get; set; }
        public DbSet<tr_bpkb> tr_bpkb { get; set; }
        public DbSet<ms_storage_location> ms_storage_location { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginModel>().HasNoKey();
            modelBuilder.Entity<ms_user>().HasNoKey();
            modelBuilder.Entity<tr_bpkb>().HasNoKey();
            modelBuilder.Entity<ms_storage_location>().HasNoKey();
            // Konfigurasi lainnya
        }
    }
}
