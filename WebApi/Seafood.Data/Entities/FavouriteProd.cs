using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class FavouriteProd : BaseEntity
    {
        public Guid? UserId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ProdBasketId { get; set; }
        public string IpRequest { get; set; }
        public string ClassName { get; set; }
    }
}
