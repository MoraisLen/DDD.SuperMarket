using System;
using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Domain.Enties;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<dynamic> Save([FromBody] DTOProduct _product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Product newProduct = new Product
                {
                    name = _product.name,
                    price = _product.price,
                    description = _product.description
                };

                productApp.Add(newProduct);

                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult<dynamic> Delete(int id)
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
        [Route("update/{id}")]
        public ActionResult<dynamic> Update([FromRoute] int id, [FromBody] DTOProduct _product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Product product = productApp.GetById(id);

                if (product == null)
                    return NotFound();

                product.name = _product.name;
                product.price = _product.price;
                product.description = _product.description;

                productApp.Update(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
