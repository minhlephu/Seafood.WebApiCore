using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.Data.Entities
{
    public class CheckCodeFirebase : BaseEntity
    {
        public string Mobile { get; set; }
        public int NumberOfSend { get; set; }
        public DateTime TimeSend { get; set; }
        public string LatestCode { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
