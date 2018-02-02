using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Models
{
    public class Merchant : BaseEntity
    {
        public long UserId { get; set; }
        public string NoApi { get; set; }
        public string Secret { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public UserWallet UserWallet { get; set; }
        public UserConfig UserConfig { get; set; }
    }
}
