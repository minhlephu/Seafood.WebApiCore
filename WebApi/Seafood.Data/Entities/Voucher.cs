using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class Voucher : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int TypeVoucher { get; set; }
        public int ReductionAmount { get; set; }
        public int? ConditionsApply { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Note { get; set; }
    }
}
