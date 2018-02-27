using Framework.Infrastructure.Core.Service;
using Framework.Module.Core.Data;
using Framework.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Services
{
    public interface IUserService : IService<GatewayManagementContext, User, long>
    {
        IEnumerable<UserPermission> PermissionByUser(long userId);

        bool ValidatePermission(long userId, string uri);

        bool ValidatePermission(string userName, string uri);
    }
}
