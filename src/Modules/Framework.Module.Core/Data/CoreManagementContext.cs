using Framework.Infrastructure.Core;
using Framework.Infrastructure.Core.Configuration;
using Framework.Infrastructure.Core.Data;
using Framework.Module.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Data
{
    public class CoreManagementContext :
        IdentityDbContext<User, Role, long, IdentityUserClaim<long>, UserRole, IdentityUserLogin<long>, IdentityRoleClaim<long>,
        IdentityUserToken<long>>, IDatabaseContext<CoreManagementContext>
    {
        public CoreManagementContext(DbContextOptions<CoreManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Type> typeToRegisters = new List<Type>();
            foreach (var module in GlobalConfiguration.Modules)
            {
                typeToRegisters.AddRange(module.Assembly.DefinedTypes.Select(t => t.AsType()));
            }

            modelBuilder.RegisterEntities(typeToRegisters);

            modelBuilder.RegisterConvention();

            base.OnModelCreating(modelBuilder);

            modelBuilder.RegisterCustomMappings(this, typeToRegisters);
        }

        public void Commit()
        {
            this.SaveChanges();
        }
    }
}
