using Framework.Infrastructure.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Models
{
    public class Transaction : BaseEntity
    {
        public long MerchantId { get; set; }
        public string Name { get; set; }
        public Merchant Merchant { get; set; }
    }
}
