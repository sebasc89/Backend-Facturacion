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

    public interface IProductService : IBaseService<ProductDTO>
    {
    }

    #endregion

    #region Service

    public class ProductService : BaseService<ProductDTO, Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository,
            IMemoryCacheManager memoryCacheManager,
            IMapper mapper,
            IConfiguration configuration)
            : base(productRepository, memoryCacheManager, mapper, configuration)
        {
            _productRepository = productRepository;
        }
    }

    #endregion
}
