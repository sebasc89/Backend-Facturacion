using DigitalWare.Facturacion.Common.Classes.Base.Services;
using DigitalWare.Facturacion.Common.Classes.DTO.Common;
using DigitalWare.Facturacion.Common.Classes.DTO.Request;
using DigitalWare.Facturacion.Common.Classes.Exceptions;
using DigitalWare.Facturacion.Common.Classes.Extensions;
using DigitalWare.Facturacion.Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWare.Facturacion.Common.Classes.Base.WebApi
{
    public abstract class BaseController<TDTO> : Controller
       where TDTO : class
    {
        IStringLocalizer<GlobalResource> _globalLocalizer;
        IBaseService<TDTO> _service;

        public BaseController(IBaseService<TDTO> service, IStringLocalizer<GlobalResource> globalLocalizer)
        {
            _service = service;
            _globalLocalizer = globalLocalizer;
        }

        public BaseController() { }

        public string Token
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Servicio para obtener todos los registros de la entidad
        /// </summary>
        /// <returns>Una lista con todos los registros de la entidad</returns>
        [HttpGet]
        [Route("getAll")]
        public virtual async Task<IActionResult> Index()
        {
            try
            {
                var data = await _service.GetAllAsync();
                return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["DefaultError"]));
            }
        }

        [HttpGet]
        [Route("details/{id:int}")]
        public virtual async Task<IActionResult> Details(int id)
        {
            try
            {
                var data = await _service.FindByIdAsync(id);
                if (data == null)
                    return Json(ResponseExtension.AsResponseDTO<string>(null,
                        (int)HttpStatusCode.NotAcceptable, _globalLocalizer["ItemNotFoundMessage"]));

                return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["DefaultError"]));
            }
        }

        [HttpPost]
        [Route("create")]
        public virtual async Task<IActionResult> Create([FromBody] TDTO modelDTO)
        {
            try
            {
                var data = await ServiceCreate(modelDTO, Token);
                return Json(data.AsResponseDTO((int)HttpStatusCode.OK,
                    _globalLocalizer["CreateSuccessMessage"]));
            }
            catch (ValidationServiceException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, ex.ToUlHtmlString()));
            }
            catch (ApplicationException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, ex.ToUlHtmlString()));
            }
            catch (Exception ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["DefaultError"]));
            }
        }

        [HttpPost]
        [Route("edit")]
        public virtual async Task<IActionResult> Edit([FromBody] TDTO modelDTO)
        {
            try
            {
                int? id = (int?)modelDTO.GetPrimaryKeyValue();
                if (!id.HasValue)
                {
                    return Json(ResponseExtension.AsResponseDTO<string>(null,
                      (int)HttpStatusCode.NotAcceptable, _globalLocalizer["ItemNotFoundMessage"]));
                }

                var data = await _service.FindByIdAsync(id);
                if (data == null)
                {
                    return Json(ResponseExtension.AsResponseDTO<string>(null,
                        (int)HttpStatusCode.NotAcceptable, _globalLocalizer["ItemNotFoundMessage"]));
                }

                var result = await ServiceUpdate(modelDTO, Token);

                return Json(result.AsResponseDTO((int)HttpStatusCode.OK,
                    _globalLocalizer["UpdateSuccessMessage"]));
            }
            catch (ValidationServiceException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, ex.ToUlHtmlString()));
            }
            catch (ApplicationException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["UpdateErrorMessage"]));
            }
            catch (Exception ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["DefaultError"]));
            }
        }

        [HttpPost]
        [Route("delete")]
        public virtual async Task<IActionResult> Delete([FromBody] RequestDTO request)
        {
            try
            {
                var data = await _service.FindByIdAsync(request.Id);

                await _service.DeleteAsync(request.Id);
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.OK, _globalLocalizer["DeleteSuccessMessage"]));
            }
            catch (ValidationServiceException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, ex.ToUlHtmlString()));
            }
            catch (ApplicationException ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, ex.ToUlHtmlString()));
            }
            catch (Exception ex)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.InternalServerError, _globalLocalizer["DefaultError"]));
            }
        }

        protected virtual async Task<TDTO> ServiceCreate(TDTO model, string token = null)
        {
            return await _service.CreateAsync(model);
        }

        protected virtual async Task<TDTO> ServiceUpdate(TDTO model, string token = null)
        {
            return await _service.UpdateAsync(model);
        }
    }
}
