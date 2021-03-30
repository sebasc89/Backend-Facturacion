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
    /// Controller to Product
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController<ProductDTO>
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
        /// IProductService
        /// </summary>
        protected IProductService _productService;

        /// <summary>
        /// Constructor of Product controller
        /// </summary>
        /// <param name="globalLocalizer"></param>
        /// <param name="configuration"></param>
        /// <param name="productService"></param>
        public ProductController(IStringLocalizer<GlobalResource> globalLocalizer, IConfiguration configuration,
            IProductService productService)
            : base(productService, globalLocalizer)
        {
            _globalLocalizer = globalLocalizer;
            _configuration = configuration;
            _productService = productService;
        }
    }
}
