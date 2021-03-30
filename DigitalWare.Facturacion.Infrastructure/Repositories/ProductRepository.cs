using DigitalWare.Facturacion.Common.Classes.Base.Repositories;
using DigitalWare.Facturacion.Infrastructure.Database.Context;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Repositories
{
    public interface IProductRepository : IBaseCRUDRepository<Product>
    {
        FacturacionContext Context { get; }
    }

    public class ProductRepository : BaseCRUDRepository<Product>, IProductRepository
    {
        public FacturacionContext Context
        {
            get
            {
                return (FacturacionContext)_Database;
            }
        }

        public ProductRepository(FacturacionContext database)
            : base(database)
        {

        }
    }
}
