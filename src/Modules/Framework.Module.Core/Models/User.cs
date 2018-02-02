using Framework.Infrastructure.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Models
{
    public class User : IdentityUser<long>, IBaseEntityWithTypeId<long>
    {
        public IList<UserRole> Roles { get; set; } = new List<UserRole>();
        public IList<UserPermission> Pages { get; set; }
    }
}
