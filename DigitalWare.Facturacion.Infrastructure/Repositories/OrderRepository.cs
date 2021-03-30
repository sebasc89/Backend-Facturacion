using DigitalWare.Facturacion.Common.Classes.Base.Repositories;
using DigitalWare.Facturacion.Infrastructure.Database.Context;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Repositories
{
    public interface IOrderRepository : IBaseCRUDRepository<Order>
    {
        FacturacionContext Context { get; }
    }

    public class OrderRepository : BaseCRUDRepository<Order>, IOrderRepository
    {
        public FacturacionContext Context
        {
            get
            {
                return (FacturacionContext)_Database;
            }
        }

        public OrderRepository(FacturacionContext database)
            : base(database)
        {

        }
    }
}
