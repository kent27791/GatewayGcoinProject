using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Infrastructure.Core.Configuration
{
    public interface ISettings
    {
        ConnectionStrings ConnectionStrings { get; set; }

        Redis Redis { get; set; }
    }
}
