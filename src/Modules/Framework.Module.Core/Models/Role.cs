using Framework.Infrastructure.Core.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Models
{
    public class Role : IdentityRole<long>, IBaseEntityWithTypeId<long>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
        public IList<RolePermission> Pages { get; set; } = new List<RolePermission>();
    }
}
