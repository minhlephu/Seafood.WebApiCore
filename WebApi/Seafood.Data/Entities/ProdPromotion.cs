using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class ProdPromotion : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public string Content { get; set; }
        public bool PromotionMain { get; set; }
        public string Note { get; set; }
    }
}
