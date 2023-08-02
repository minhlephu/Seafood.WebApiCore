using Microsoft.EntityFrameworkCore;
using Seafood.Data.Entities;

namespace Seafood.Data.EF
{
    public class SeafoodDbcontext : DbContext
    {
        public SeafoodDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckCodeFirebase> CheckCodeFirebases { get; set; }
        public DbSet<FavouriteProd> FavouriteProds { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProdInfo> ProdInfos { get; set; }
        public DbSet<ProdProcessing> ProdProcessings { get; set; }
        public DbSet<ProdPromotion> ProdPromotions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<SeafoodPromotion> SeafoodPromotions { get; set; }
        public DbSet<ShopSeafood> ShopSeafoods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAdmin> UserAdmins { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherSeafood> VoucherSeafoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
