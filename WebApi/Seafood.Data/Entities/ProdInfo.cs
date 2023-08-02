using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class ProdInfo : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
