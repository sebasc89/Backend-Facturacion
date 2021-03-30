using DigitalWare.Facturacion.Common.Classes.Base.WebApi;
using DigitalWare.Facturacion.Common.Classes.DTO.Domain;
using DigitalWare.Facturacion.Common.Resources;
using DigitalWare.Facturacion.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.WebApi.Controllers
{
    /// <summary>
    /// Controller to Category
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : BaseController<CategoryDTO>
    {
        /// <summary>
        /// IStringLocalizer
        /// </summary>
        protected IStringLocalizer<GlobalResource> _globalLocalizer;

        /// <summary>
        /// IConfiguration
        /// </summary>
        protected IConfiguration _configuration;

        /// <summary>
        /// ICategoryService
        /// </summary>
        protected ICategoryService _categoryService;

        /// <summary>
        /// Constructor of Category controller
        /// </summary>
        /// <param name="globalLocalizer"></param>
        /// <param name="configuration"></param>
        /// <param name="categoryService"></param>
        public CategoryController(IStringLocalizer<GlobalResource> globalLocalizer, IConfiguration configuration,
            ICategoryService categoryService)
            : base(categoryService, globalLocalizer)
        {
            _globalLocalizer = globalLocalizer;
            _configuration = configuration;
            _categoryService = categoryService;
        }
    }
}
