using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity.Workers;
using System.Net;
using System.Web.Http;

namespace Crea_DiegoA.Api.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerWorker customerWorker;

        public CustomerController()
        {
            customerWorker = new CustomerWorker();
        }

        [HttpPost]
        [Route("api/customer/create")]
        public IHttpActionResult Create([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return (BadRequest(ModelState));
            }

            if (!customerWorker.Create(customerDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el cliente " + customerDto.FirtsName);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("Cliente creado con éxito");
            }
        }

        [HttpPost]
        [Route("api/customer/update")]
        public IHttpActionResult Update([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return (BadRequest(ModelState));
            }

            if (!customerWorker.Update(customerDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar el cliente " + customerDto.FirtsName);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("Cliente actualizado con éxito");
            }
        }

        [HttpGet]
        [Route("api/customer/desactive/{document}")]
        public IHttpActionResult Desactive(string document)
        {
            if (string.IsNullOrEmpty(document))
            {
                return (BadRequest(ModelState));
            }

            if (!customerWorker.ChangeState(document, false))
            {
                ModelState.AddModelError("", "Ocurrió un error al desactivar el cliente " + document);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("Cliente desactivado con éxito");
            }
        }

        [HttpGet]
        [Route("api/customer/search/{name}")]
        public IHttpActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (BadRequest(ModelState));
            }

            var customer = customerWorker.SearchByName(name);

            if (customer == null)
            {
                ModelState.AddModelError("", "No se pudo encontrar el cliente " + name);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok(customer);
            }
        }
    }
}
