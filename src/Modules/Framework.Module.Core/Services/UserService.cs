using Framework.Infrastructure.Core.Data;
using Framework.Infrastructure.Service;
using Framework.Module.Core.Data;
using Framework.Module.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.Services
{
    public class UserService : BaseService<CoreManagementContext, User, long>, IUserService
    {
        public UserService(IRepository<CoreManagementContext, User, long> repository) : base(repository)
        {

        }

        public IEnumerable<UserPermission> PermissionByUser(long userId)
        {
            var result = this._repository
                             .Query()
                             .Include(u => u.Pages)
                             .Select(u => u.Pages.Where(up => up.UserId == userId))
                             .SingleOrDefault();
            return result;
        }

        public bool ValidatePermission(long userId, string uri)
        {
            var result = this._repository
                             .Query()
                             .Any(u => u.Pages.Any(up => up.UserId == userId && up.Page.Uri == uri));
            return result;
        }

        public bool ValidatePermission(string userName, string uri)
        {
            var result = this._repository
                              .Query()
                              .Any(u => u.UserName == userName && u.Pages.Any(up => up.Page.Uri == uri));
            return result;
        }
    }
}
