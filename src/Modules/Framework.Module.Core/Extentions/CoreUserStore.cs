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
    public class CoreUserStore : UserStore<User, Role, CoreManagementContext, long, IdentityUserClaim<long>, UserRole,
        IdentityUserLogin<long>, IdentityUserToken<long>, IdentityRoleClaim<long>>
    {
        public CoreUserStore(CoreManagementContext context, IdentityErrorDescriber describer) : base(context, describer)
        {

        }
    }
}
