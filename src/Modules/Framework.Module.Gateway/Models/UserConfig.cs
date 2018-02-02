using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Models
{
    public class UserConfig : BaseEntity
    {
        public decimal LimitReceive { get; set; }
        public decimal LimitSent { get; set; }
        public decimal CommissionReceive { get; set; }
        public decimal CommissionSent { get; set; }
        public string GcoinNoApi { get; set; }
        public string GcoinSecret { get; set; }
        public string GcoinNoPhone { get; set; }
        public UserWallet UserWallet { get; set; }
        public IList<Merchant> Merchants { get; set; }

    }
}
