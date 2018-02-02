using Framework.Module.Core.Data;
using Framework.Module.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Extentions
{
    public class CoreRoleStore : RoleStore<Role, CoreManagementContext, long, UserRole, IdentityRoleClaim<long>>
    {
        public CoreRoleStore(CoreManagementContext context, IdentityErrorDescriber describer)
            : base(context, describer)
        {

        }
    }
}
