using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class SeafoodPromotion : BaseEntity
    {
        public string ShopCode { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
    }
}
