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
    /// Controller to Order
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController<OrderDTO>
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
        /// IOrderService
        /// </summary>
        protected IOrderService _orderService;

        /// <summary>
        /// Constructor of Order controller
        /// </summary>
        /// <param name="globalLocalizer"></param>
        /// <param name="configuration"></param>
        /// <param name="orderService"></param>
        public OrderController(IStringLocalizer<GlobalResource> globalLocalizer, IConfiguration configuration,
            IOrderService orderService)
            : base(orderService, globalLocalizer)
        {
            _globalLocalizer = globalLocalizer;
            _configuration = configuration;
            _orderService = orderService;
        }
    }
}
