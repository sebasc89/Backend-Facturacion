using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Common.Classes.Base.Repositories
{
    public interface ICreateRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity, bool autoSave = true);
        T Create(T entity, bool autoSave = true);
    }
}
