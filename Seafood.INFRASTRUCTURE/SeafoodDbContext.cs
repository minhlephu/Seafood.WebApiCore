using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE.Base.Interfaces;

namespace Seafood.INFRASTRUCTURE;

public partial class SeafoodDbContext : DbContext, ISeafoodDbContext
{
    public SeafoodDbContext()
    {
    }

    public SeafoodDbContext(DbContextOptions<SeafoodDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Category> Categorys { get; set; }

    public virtual DbSet<CheckCodeFirebasis> CheckCodeFirebases { get; set; }

    public virtual DbSet<FavouriteProd> FavouriteProds { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<ProdInfo> ProdInfos { get; set; }

    public virtual DbSet<ProdProcessing> ProdProcessings { get; set; }

    public virtual DbSet<ProdPromotion> ProdPromotions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SeafoodPromotion> SeafoodPromotions { get; set; }

    public virtual DbSet<SessionAuthorize> SessionAuthorizes { get; set; }

    public virtual DbSet<SessionAuthorizeAdmin> SessionAuthorizeAdmins { get; set; }

    public virtual DbSet<ShopSeafood> ShopSeafoods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherSeafood> VoucherSeafoods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=V000284\\MSSQLSERVER01;Database=Seafood;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Addresse__3214EC0751E4974C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Baskets__3214EC074BAC0539");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC0752971FAC");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<CheckCodeFirebasis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CheckCod__3214EC073B1D5BD8");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LatestCode).IsFixedLength();
            entity.Property(e => e.Mobile).IsFixedLength();
        });

        modelBuilder.Entity<FavouriteProd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Favourit__3214EC072777BE6C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Images__3214EC07A313FF14");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07385547D7");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProdInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdInfo__3214EC073A8D937A");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DeletedAt).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<ProdProcessing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdProc__3214EC078899DE2C");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<ProdPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProdProm__3214EC0734D46F5F");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC071B6F98DD");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Regions__3214EC07E5810499");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SeafoodPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SeefoodP__3214EC07989C219A");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SessionAuthorize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SessionA__3214EC075DCE331C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Username).IsFixedLength();
        });

        modelBuilder.Entity<SessionAuthorizeAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SessionA__3214EC07E2326B24");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Username).IsFixedLength();
        });

        modelBuilder.Entity<ShopSeafood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ShopSeaf__3214EC0720AC06CC");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC072E83A939");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsAdminUser).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsLocked).HasDefaultValueSql("((0))");
            entity.Property(e => e.Mobile).IsFixedLength();
            entity.Property(e => e.PasswordHash).IsFixedLength();
            entity.Property(e => e.Salt).IsFixedLength();
            entity.Property(e => e.Sex).HasDefaultValueSql("((1))");
            entity.Property(e => e.Username).IsFixedLength();
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vouchers__3214EC075DC24999");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<VoucherSeafood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VoucherS__3214EC071896CEEA");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
