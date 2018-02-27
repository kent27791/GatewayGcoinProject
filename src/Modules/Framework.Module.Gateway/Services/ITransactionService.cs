using Framework.Infrastructure.Core.Service;
using Framework.Module.Core.Data;
using Framework.Module.Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Framework.Module.Gateway.Services
{
    public interface ITransactionService : IService<GatewayManagementContext, Transaction, long>
    {

    }
}
