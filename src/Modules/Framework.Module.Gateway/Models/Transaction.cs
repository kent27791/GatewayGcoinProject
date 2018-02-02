using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Models
{
    public class Transaction : BaseEntity
    {
        public string GatewayId { get; set; }
        public string GcoinId { get; set; }
        public string PartnerId { get; set; }
        public long MerchantId { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public decimal Gcoin { get; set; }
        public string Result { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Merchant Merchant { get; set; }
    }
}
