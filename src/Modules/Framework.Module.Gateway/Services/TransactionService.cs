using Framework.Infrastructure.Core.Data;
using Framework.Infrastructure.Service;
using Framework.Module.Core.Data;
using Framework.Module.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Gateway.Services
{
    public class TransactionService : BaseService<CoreManagementContext, Transaction, long>, ITransactionService
    {
        public TransactionService(IRepository<CoreManagementContext, Transaction, long> repository) : base(repository)
        {

        }
    }
}
