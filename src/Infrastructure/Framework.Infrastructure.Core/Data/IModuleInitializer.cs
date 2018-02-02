using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Infrastructure.Core.Data
{
    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }
}
