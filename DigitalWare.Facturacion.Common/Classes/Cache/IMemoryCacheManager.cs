using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Common.Classes.Cache
{
    public interface IMemoryCacheManager : IEnumerable<KeyValuePair<object, object>>, IMemoryCache
    {
        void Clear();
    }
}
