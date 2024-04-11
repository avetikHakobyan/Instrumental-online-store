using avhH60Common.Models;
using Microsoft.EntityFrameworkCore;

namespace avhH60Services.DAL
{
    public partial class H60Assignment3DB_avhContext : DbContext
    {
        public H60Assignment3DB_avhContext()
        {
        }

        public H60Assignment3DB_avhContext(DbContextOptions<H60Assignment3DB_avhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<CartItem> CartItem { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItem { get; set; } = null!;
        public virtual DbSet<Order> Order { get; set; } = null!;
        public virtual DbSet<Customer> Customer { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:MyConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.ProdCatId, "IX_Product_ProdCatId");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.BuyPrice).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.Description)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SellPrice).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.ProdCat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProdCatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("ProductCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProdCat)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCategory>().HasData(
        new ProductCategory() { CategoryId = 1, ProdCat = "Hip hop" },
        new ProductCategory() { CategoryId = 2, ProdCat = "Pop" },
        new ProductCategory() { CategoryId = 3, ProdCat = "R&B" },
        new ProductCategory() { CategoryId = 4, ProdCat = "Rock" },
        new ProductCategory() { CategoryId = 5, ProdCat = "Reggae" }
    );

            modelBuilder.Entity<Product>().HasData(
                    new Product() { ProductId = 1, ProdCatId = 1, Description = "Too Deep", Manufacturer = "Roma", Stock = 8, BuyPrice = (decimal)25.00, SellPrice = (decimal)100.00 },
                    new Product() { ProductId = 2, ProdCatId = 1, Description = "No No No", Manufacturer = "Kaddy", Stock = 9, BuyPrice = (decimal)20.00, SellPrice = (decimal)90.00 },
                    new Product() { ProductId = 3, ProdCatId = 1, Description = "Eureka", Manufacturer = "Junkey", Stock = 0, BuyPrice = (decimal)34.95, SellPrice = (decimal)174.75 },
                    new Product() { ProductId = 4, ProdCatId = 1, Description = "Winner", Manufacturer = "Storm", Stock = 10, BuyPrice = (decimal)30.00, SellPrice = (decimal)150.00 },

                    new Product() { ProductId = 5, ProdCatId = 2, Description = "Feelings", Manufacturer = "Jurrivh", Stock = 13, BuyPrice = (decimal)14.95, SellPrice = (decimal)74.75 },
                    new Product() { ProductId = 6, ProdCatId = 2, Description = "Fuego", Manufacturer = "Encore", Stock = 9, BuyPrice = (decimal)20.00, SellPrice = (decimal)90.00 },
                    new Product() { ProductId = 7, ProdCatId = 2, Description = "Let it Go", Manufacturer = "Junkey", Stock = 18, BuyPrice = (decimal)34.95, SellPrice = (decimal)174.75 },
                    new Product() { ProductId = 8, ProdCatId = 2, Description = "I'm fine", Manufacturer = "Storm", Stock = 10, BuyPrice = (decimal)30.00, SellPrice = (decimal)150.00 },

                    new Product() { ProductId = 9, ProdCatId = 3, Description = "Party", Manufacturer = "JustBen", Stock = 8, BuyPrice = (decimal)25.00, SellPrice = (decimal)100.00 },
                    new Product() { ProductId = 10, ProdCatId = 3, Description = "Forever", Manufacturer = "Black Lions", Stock = 9, BuyPrice = (decimal)20.00, SellPrice = (decimal)90.00 },
                    new Product() { ProductId = 11, ProdCatId = 3, Description = "Mine", Manufacturer = "ProducerX", Stock = 0, BuyPrice = (decimal)34.95, SellPrice = (decimal)174.75 },
                    new Product() { ProductId = 12, ProdCatId = 3, Description = "Say My Name", Manufacturer = "Anyvibe", Stock = 10, BuyPrice = (decimal)30.00, SellPrice = (decimal)150.00 },

                    new Product() { ProductId = 13, ProdCatId = 4, Description = "Too Deep", Manufacturer = "Horizon", Stock = 8, BuyPrice = (decimal)25.00, SellPrice = (decimal)100.00 },
                    new Product() { ProductId = 14, ProdCatId = 4, Description = "No promises", Manufacturer = "Rob", Stock = 9, BuyPrice = (decimal)20.00, SellPrice = (decimal)90.00 },
                    new Product() { ProductId = 15, ProdCatId = 4, Description = "Answers", Manufacturer = "IVN", Stock = 18, BuyPrice = (decimal)34.95, SellPrice = (decimal)174.75 },
                    new Product() { ProductId = 16, ProdCatId = 4, Description = "Texas", Manufacturer = "Classy", Stock = 10, BuyPrice = (decimal)30.00, SellPrice = (decimal)150.00 },

                    new Product() { ProductId = 17, ProdCatId = 5, Description = "Final Chapter", Manufacturer = "Cold Melody", Stock = 8, BuyPrice = (decimal)25.00, SellPrice = (decimal)100.00 },
                    new Product() { ProductId = 18, ProdCatId = 5, Description = "Too late", Manufacturer = "Fantom", Stock = 9, BuyPrice = (decimal)20.00, SellPrice = (decimal)90.00 },
                    new Product() { ProductId = 19, ProdCatId = 5, Description = "Energy", Manufacturer = "Shyy", Stock = 18, BuyPrice = (decimal)34.95, SellPrice = (decimal)174.75 },
                    new Product() { ProductId = 20, ProdCatId = 5, Description = "Damage", Manufacturer = "JakeAngel", Stock = 10, BuyPrice = (decimal)30.00, SellPrice = (decimal)150.00 }
                );

            modelBuilder.Entity<Customer>().HasData(
                    new Customer() { CustomerId = 1, FirstName = "Jayson", LastName = "Brunet", Email = "jbrunet@gmail.com", PhoneNumber = "8191234567", Province = "QC", CreditCard = "5521837021042177" },
                new Customer() { CustomerId = 2, FirstName = "Simon-Olivier", LastName = "Drapeau", Email = "sodrapeau@gmail.com", PhoneNumber = "6131234567", Province = "ON", CreditCard = "6649212508652229" },
                new Customer() { CustomerId = 3, FirstName = "Richard", LastName = "Chan", Email = "rchan@gmail.com", PhoneNumber = "8731234567", Province = "QC", CreditCard = "7470308034834181" }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order() { OrderId = 1, CustomerId = 1, DateCreated = new DateTime(2023, 03, 3), DateFulfilled = new DateTime(2023, 03, 14), Total = (decimal)114.98, Taxes = (decimal)14.98 },
                new Order() { OrderId = 2, CustomerId = 2, DateCreated = new DateTime(2023, 04, 6), DateFulfilled = new DateTime(2022, 04, 16), Total = (decimal)200.06, Taxes = (decimal)26.06 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem() { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 1, Price = (decimal)100.00 },
                new OrderItem() { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 1, Price = (decimal)90.00 },
                new OrderItem() { OrderItemId = 3, OrderId = 1, ProductId = 3, Quantity = 1, Price = (decimal)174.75 },
                new OrderItem() { OrderItemId = 4, OrderId = 2, ProductId = 4, Quantity = 2, Price = (decimal)300.00 }
            );

            modelBuilder.Entity<ShoppingCart>().HasData(
                    new ShoppingCart() { ShoppingCartId = 1, CustomerId = 1, DateCreated = new DateTime(2023, 04, 06) }
                );

            modelBuilder.Entity<CartItem>().HasData(
                    new CartItem() { CartItemId = 1, ShoppingCartId = 1, ProductId = 1, Quantity = 1, Price = (decimal)100.00 },
                    new CartItem() { CartItemId = 2, ShoppingCartId = 1, ProductId = 1, Quantity = 2, Price = (decimal)200.00 }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
