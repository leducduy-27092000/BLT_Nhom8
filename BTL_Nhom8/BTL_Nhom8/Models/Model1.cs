using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_Nhom8.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Web_Cay_Canh")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product_Image> Product_Image { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Detail_Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Product_Image)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
