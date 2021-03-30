using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Common.Classes.Cache
{
    public static class MemoryCacheExtensions
    {

        public static async Task<TItem> GetOrCreateAsync<TItem>(this IMemoryCacheManager cache, object key, Func<ICacheEntry, Task<TItem>> factory)
        {
            //Consultamos si existe el key con el valor de la cache correspondiente
            if (!cache.TryGetValue(key, out object result))
            {
                //Si no existe el key lo creamos y enviamos el valor a la cache
                var entry = cache.CreateEntry(key);
                var resultEntry = await factory(entry);
                entry.SetValue(resultEntry);
                entry.Dispose();

                return (TItem)resultEntry;
            }
            else
            {
                //Si existe el key retornamos el resultado con el valor en cache
                return (TItem)result;
            }
        }

    }
}
