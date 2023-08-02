using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class Image : BaseEntity
    {
        public Guid? ProductId { get; set; }
        public Guid? ShopSeafoodId { get; set; }
        public Guid? MoreImgId { get; set; }
        public string UrlPath { get; set; }
        public string Base64Str { get; set; }
        public bool IsImageMain { get; set; }
    }
}
