using DigitalWare.Facturacion.Common.Classes.Base.Repositories;
using DigitalWare.Facturacion.Infrastructure.Database.Context;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Repositories
{
    public interface ICustomerRepository : IBaseCRUDRepository<Customer>
    {
        FacturacionContext Context { get; }
    }

    public class CustomerRepository : BaseCRUDRepository<Customer>, ICustomerRepository
    {
        public FacturacionContext Context
        {
            get
            {
                return (FacturacionContext)_Database;
            }
        }

        public CustomerRepository(FacturacionContext database)
            : base(database)
        {

        }
    }
}
