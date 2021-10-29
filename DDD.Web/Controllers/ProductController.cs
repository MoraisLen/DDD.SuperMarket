using DDD.Application.Interfaces;
using DDD.Domain.Enties;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DDD.Web.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class ProductController : Controller
    {
        private readonly IProductApp productApp;

        public ProductController(IProductApp _productApp)
        {
            productApp = _productApp;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<dynamic> GetAll()
        {
            try
            {
                return productApp.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult<dynamic> Get([FromRoute] int id)
        {
            try
            {
                var product = productApp.GetById(id);

                return (product != null) ? product : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public ActionResult<dynamic> Save([FromBody] Product product)
        {
            try
            {
                productApp.Add(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult<dynamic> Delete([FromBody] int id)
        {
            try
            {
                var product = productApp.GetById(id);

                if (product == null)
                    return NotFound();

                productApp.Remove(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<dynamic> Update([FromBody] Product _product)
        {
            try
            {
                var product = productApp.GetById(_product.id);

                if (product == null)
                    return NotFound();

                productApp.Update(_product);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
