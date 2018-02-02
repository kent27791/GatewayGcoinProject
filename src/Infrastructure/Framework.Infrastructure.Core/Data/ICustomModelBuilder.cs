using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Infrastructure.Core.Data
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
        //string ContextName { get; }
    }
}
