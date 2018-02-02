using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Infrastructure.Core.Domain
{
    public interface IBaseEntityWithTypeId<TKey>
    {
        TKey Id { get; set; }
    }
}
