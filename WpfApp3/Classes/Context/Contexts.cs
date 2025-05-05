
using Microsoft.EntityFrameworkCore;
using yp02.Classes;

namespace Master_Pol.Classes.Context
{
    public class Contexts : DbContext
    {
        public static readonly string StrConnect = "server=localhost;port=3303;uid=root;database=base2;";
        public static MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new System.Version(8, 0, 11));

        public DbSet<Materials> Materials { get; set; }
        public DbSet<Partner_Products> Partner_Products { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Required_Material> Required_Material { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Type_Partner> Type_Partner { get; set; }
        public DbSet<Type_Product> Type_Product { get; set; }
        public DbSet<GetChanges> GetChanges { get; set; }

        public Contexts() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetChanges>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql(StrConnect, mySqlServerVersion);
    }
}

