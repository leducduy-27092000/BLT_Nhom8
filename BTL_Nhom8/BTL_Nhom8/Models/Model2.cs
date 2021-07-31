using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_Nhom8.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=WebCayCanh")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DetailProduct_Order> DetailProduct_Order { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product_Image> Product_Image { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Roles_Account").MapLeftKey("Account_Id").MapRightKey("Role_Id"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.DetailProduct_Order)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.DetailProduct_Order)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Image)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
