using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity;
using Crea_DiegoA.Core.Enums;
using System;
using System.Net;
using System.Web.Http;

namespace Crea_DiegoA.Api.Controllers
{
    public class SaleController : ApiController
    {
        private readonly ISaleWorker saleWorker;

        public SaleController()
        {
            saleWorker = new SaleWorker();
        }

        [HttpPost]
        [Route("api/sale/create")]
        public IHttpActionResult Create([FromBody] SaleDto saleDto)
        {
            if (saleDto == null)
            {
                return (BadRequest(ModelState));
            }

            saleDto.SalesGuid = Guid.NewGuid();

            if (!saleWorker.Create(saleDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al crear la venta ");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("venta creada con éxito");
            }
        }

        [HttpPost]
        [Route("api/sale/update")]
        public IHttpActionResult Update([FromBody] SaleDto saleDto)
        {
            if (saleDto == null)
            {
                return (BadRequest(ModelState));
            }

            if (!saleWorker.Update(saleDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar la venta ");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("venta actualizada con éxito");
            }
        }

        [HttpGet]
        [Route("api/sale/changeState/{id}/{state}")]
        public IHttpActionResult ChangeState(int id, int state)
        {
            if (id == 0)
            {
                return (BadRequest(ModelState));
            }

            StateTypes.States stateType = (StateTypes.States)Enum.ToObject(typeof(StateTypes.States), state);

            if (!saleWorker.ChangeState(id, stateType))
            {
                ModelState.AddModelError("", "Ocurrió un error al desactivar la venta " + id);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("El estado de la venta, se modificó con éxito");
            }
        }

        [HttpGet]
        [Route("api/sale/search/{salesID}")]
        public IHttpActionResult Search(string salesID)
        {
            if (string.IsNullOrEmpty(salesID))
            {
                return (BadRequest(ModelState));
            }

            var sale = saleWorker.Search(Guid.Parse(salesID));

            if (sale == null)
            {
                ModelState.AddModelError("", "No se pudo encontrar la venta " + salesID);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok(sale);
            }
        }
    }
}
