using Crea_DiegoA.Core.DTOs;
using Crea_DiegoA.Core.Reposity;
using System.Net;
using System.Web.Http;

namespace Crea_DiegoA.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductWorker productWorker;

        public ProductController()
        {
            productWorker = new ProductWorker();
        }

        [HttpPost]
        [Route("api/product/create")]
        public IHttpActionResult Create([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return (BadRequest(ModelState));
            }

            if (!productWorker.Create(productDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al crear el producto " + productDto.Name);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("producto creado con éxito");
            }
        }

        [HttpPost]
        [Route("api/product/update")]
        public IHttpActionResult Update([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return (BadRequest(ModelState));
            }

            if (!productWorker.Update(productDto))
            {
                ModelState.AddModelError("", "Ocurrió un error al actualizar el producto " + productDto.Name);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("producto actualizado con éxito");
            }
        }

        [HttpGet]
        [Route("api/product/desactive/{productID}")]
        public IHttpActionResult Desactive(int productID)
        {
            if (productID == 0)
            {
                return (BadRequest(ModelState));
            }

            if (!productWorker.ChangeState(productID, false))
            {
                ModelState.AddModelError("", "Ocurrió un error al desactivar el producto " + productID);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok("producto desactivado con éxito");
            }
        }

        [HttpGet]
        [Route("api/product/search/{name}")]
        public IHttpActionResult Search(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (BadRequest(ModelState));
            }

            var product = productWorker.Search(name);

            if (product == null)
            {
                ModelState.AddModelError("", "No se pudo encontrar el producto " + name);
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Ok(product);
            }
        }
    }
}
