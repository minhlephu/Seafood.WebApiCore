using Microsoft.EntityFrameworkCore;
using Seafood.ARCHITECTURE.Entities.Models;

namespace Seafood.CORE.Base.Interfaces
{
    public interface ISeafoodDbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<CheckCodeFirebasis> CheckCodeFirebases { get; set; }

        public DbSet<FavouriteProd> FavouriteProds { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProdInfo> ProdInfos { get; set; }

        public DbSet<ProdProcessing> ProdProcessings { get; set; }

        public DbSet<ProdPromotion> ProdPromotions { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<SeafoodPromotion> SeafoodPromotions { get; set; }

        public DbSet<SessionAuthorize> SessionAuthorizes { get; set; }

        public DbSet<SessionAuthorizeAdmin> SessionAuthorizeAdmins { get; set; }

        public DbSet<ShopSeafood> ShopSeafoods { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }

        public DbSet<VoucherSeafood> VoucherSeafoods { get; set; }
    }
}
