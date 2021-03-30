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

    public interface IOrderService : IBaseService<OrderDTO>
    {
    }
    #endregion

    #region Service

    public class OrderService : BaseService<OrderDTO, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IMemoryCacheManager memoryCacheManager,
            IMapper mapper,
            IConfiguration configuration)
            : base(orderRepository, memoryCacheManager, mapper, configuration)
        {
            _orderRepository = orderRepository;
        }
    }

    #endregion
}
