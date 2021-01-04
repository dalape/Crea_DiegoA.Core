using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity.Workers;
using Crea_DiegoA.Core.Enums;
using System;
using System.Net;
using System.Web.Http;

namespace Crea_DiegoA.Api.Controllers
{
    public class SaleController : ApiController
    {
        private readonly ISaleWorker saleWorker;
        private readonly IProductWorker productWorker;
        private readonly ICustomerWorker customerWorker;

        public SaleController()
        {
            saleWorker = new SaleWorker();
            productWorker = new ProductWorker();
            customerWorker = new CustomerWorker();
        }

        [HttpPost]
        [Route("api/sale/create")]
        public IHttpActionResult Create([FromBody] SaleDto saleDto)
        {
            if (saleDto == null)
            {
                return (BadRequest(ModelState));
            }

            var customer = customerWorker.Search(saleDto.CustomerID);

            if (!Convert.ToBoolean(customer.Enable))
            {
                return (BadRequest($"El cliente {saleDto.CustomerID} se encuentra desactivado. No se puede realizar la venta."));
            }

            var product = productWorker.Search(saleDto.ProductID);

            if (!Convert.ToBoolean(product.Enable))
            {
                return (BadRequest($"El producto {saleDto.ProductID} se encuentra desactivado. No se puede realizar la venta."));
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

            if (!Enum.IsDefined(typeof(StateTypes.States), state))
            {
                return (BadRequest($"No existe estado de venta con el código {state}"));
            }

            StateTypes.States stateType = (StateTypes.States)Enum.ToObject(typeof(StateTypes.States), state);

            if (!saleWorker.ChangeState(id, stateType))
            {
                ModelState.AddModelError("", "Ocurrió un error al cambiar el estado de la venta " + id);
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
