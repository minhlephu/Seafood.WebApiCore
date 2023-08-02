using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public  class Address : BaseEntity
    {
        public Guid UserId { get; set; }
        public int TypeAddress { get; set; }
        public int TypeAddressDetail { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string CodeRegion { get; set; }
        public string CodeDistrict { get; set; }
        public string CodeWard { get; set; }
        public bool IsAddressMain { get; set; }
        public string Address1 { get; set; }
        public string Note { get; set; }
    }
}
