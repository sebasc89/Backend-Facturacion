using AutoMapper;
using DigitalWare.Facturacion.Common.Classes.Base.Services;
using DigitalWare.Facturacion.Common.Classes.Cache;
using DigitalWare.Facturacion.Common.Classes.DTO.Domain;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using DigitalWare.Facturacion.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Domain.Services
{
    #region IService

    public interface ICustomerService : IBaseService<CustomerDTO>
    {
    }

    #endregion

    #region Service

    public class CustomerService : BaseService<CustomerDTO, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IMemoryCacheManager memoryCacheManager,
            IMapper mapper,
            IConfiguration configuration)
            : base(customerRepository, memoryCacheManager, mapper, configuration)
        {
            _customerRepository = customerRepository;
        }
    }

    #endregion
}
