using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Models
{
    public class UserWallet : BaseEntity
    {
        public decimal WalletReceive { get; set; }
        public decimal WalletSent { get; set; }
        public UserConfig UserConfig { get; set; }
        public IList<Merchant> Merchants { get; set; }
    }
}
