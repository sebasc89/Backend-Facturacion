using DigitalWare.Facturacion.Common.Classes.Base.Repositories;
using DigitalWare.Facturacion.Infrastructure.Database.Context;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Repositories
{
    public interface ICategoryRepository : IBaseCRUDRepository<Category>
    {
        FacturacionContext Context { get; }
    }

    public class CategoryRepository : BaseCRUDRepository<Category>, ICategoryRepository
    {
        public FacturacionContext Context
        {
            get
            {
                return (FacturacionContext)_Database;
            }
        }

        public CategoryRepository(FacturacionContext database)
            : base(database)
        {

        }
    }
}
