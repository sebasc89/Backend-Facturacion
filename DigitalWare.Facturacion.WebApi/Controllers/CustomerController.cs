
using DigitalWare.Facturacion.Common.Classes.Base.WebApi;
using DigitalWare.Facturacion.Common.Classes.DTO.Domain;
using DigitalWare.Facturacion.Common.Resources;
using DigitalWare.Facturacion.Domain.Services;
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
    /// Controller to Customer
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : BaseController<CustomerDTO>
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
        /// ICustomerService
        /// </summary>
        protected ICustomerService _customerService;

        /// <summary>
        /// Constructor of Customer controller
        /// </summary>
        /// <param name="globalLocalizer"></param>
        /// <param name="configuration"></param>
        /// <param name="customerService"></param>
        public CustomerController(IStringLocalizer<GlobalResource> globalLocalizer, IConfiguration configuration,
            ICustomerService customerService)
            : base(customerService, globalLocalizer)
        {
            _globalLocalizer = globalLocalizer;
            _configuration = configuration;
            _customerService = customerService;
        }
    }
}
