using AutoMapper;
using DigitalWare.Facturacion.Common.Classes.Base.Services;
using DigitalWare.Facturacion.Common.Classes.Cache;
using DigitalWare.Facturacion.Common.Classes.DTO.Domain;
using DigitalWare.Facturacion.Common.Classes.Validator;
using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using DigitalWare.Facturacion.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Domain.Services
{
    #region IService

    public interface ICategoryService : IBaseService<CategoryDTO>
    {
    }

    #endregion

    #region Service

    public class CategoryService : BaseService<CategoryDTO, Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMemoryCacheManager memoryCacheManager,
            IMapper mapper,
            IConfiguration configuration)
            : base(categoryRepository, memoryCacheManager, mapper, configuration)
        {
            _categoryRepository = categoryRepository;
        }
    }

    #endregion
}
