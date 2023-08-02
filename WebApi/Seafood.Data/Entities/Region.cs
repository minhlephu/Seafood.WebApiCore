using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class Region : BaseEntity
    {
        public string NameRegion { get; set; }
        public string CodeRegion { get; set; }
        public string NameDistrict { get; set; }
        public string CodeDistrict { get; set; }
        public string NameWard { get; set; }
        public string CodeWard { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

    }
}
