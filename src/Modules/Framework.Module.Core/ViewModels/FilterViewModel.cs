using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Module.Core.ViewModels
{
    public class FilterViewModel
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }
    }
}
