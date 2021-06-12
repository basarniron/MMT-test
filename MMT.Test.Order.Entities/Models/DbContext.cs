using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MMT.Test.Order.Core.Constants;

#nullable disable

namespace MMT.Test.Order.Entities.Model
{
    public partial class MmtContext : DbContext
    {
        #region Members

        private readonly IConfiguration _configuration;

        #endregion

        public MmtContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MmtContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderitem> Orderitems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration[ConfigurationConstants.DefaultConntectionString]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Orderitem>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.Orderid)
                    .HasConstraintName("FK__ORDERITEM__ORDER__68487DD7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderitems)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK__ORDERITEM__PRODU__693CA210");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
