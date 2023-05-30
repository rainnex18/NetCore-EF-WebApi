using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL.Models.DB;

public partial class AcmeDbContext : DbContext
{
    public AcmeDbContext(DbContextOptions<AcmeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().ToTable("Customer");
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(x => x.Price)
            .HasColumnType("decimal(18, 4)")
            .IsRequired()
            .HasDefaultValue(0);
        });
        modelBuilder.Entity<Review>().ToTable("Review");

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                FirstName = "Alice",
                LastName = "A",
                Email = "alice@email.com",
                Phone = "1234567890",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Benji",
                LastName = "B",
                Email = "benji@email.com",
                Phone = "1234567890",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Carry",
                LastName = "C",
                Email = "carry@email.com",
                Phone = "1234567890",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            });

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Cherry Tomato",
                Descs = "Fresh, Organic",
                Price = (decimal)50.00,
                ImgUrl = "https://picsum.photos/200/300",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            },
            new Product
            {
                Id = 2,
                Name = "Butter Cookie",
                Descs = "Originating in Denmark",
                Price = (decimal)80.00,
                ImgUrl = "https://picsum.photos/200/300",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            },
            new Product
            {
                Id = 3,
                Name = "Evian Natural Spring Water",
                Descs = "It's a uniquely sourced spring water that's always refreshing and naturally hydrating, with nothing added for taste",
                Price = (decimal)4.00,
                ImgUrl = "https://picsum.photos/200/300",
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "System",
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "System"
            });
    }

    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ver)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Descs).HasMaxLength(300);
            entity.Property(e => e.ImgUrl).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ver)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ver)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Customer).WithMany(p => p.ReviewsNavigation)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__Customer__29572725");

            entity.HasOne(d => d.Product).WithMany(p => p.ReviewsNavigation)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__ProductI__286302EC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder); 
    */
}
