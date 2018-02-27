using Framework.Infrastructure.Core.Data;
using Framework.Infrastructure.Service;
using Framework.Module.Core.Data;
using Framework.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Services
{
    public class RoleService : BaseService<GatewayManagementContext, Role, long>, IRoleService
    {
        public RoleService(IRepository<GatewayManagementContext, Role, long> repository) : base(repository)
        {

        }
    }
}
