using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Infrastructure.Core.Configuration
{
    public class MySettings : ISettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Redis Redis { get; set; }
    }
}
