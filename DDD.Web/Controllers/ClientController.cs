using System;
using DDD.Application.DTO;
using DDD.Application.Interfaces;
using DDD.Domain.Enties;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Web.Controllers
{
    [ApiController]
    [Route("api/v1/client/")]
    public class ClientController : Controller
    {
        private readonly IClientApp clientApp;

        public ClientController(IClientApp _clientApp)
        {
            clientApp = _clientApp;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<dynamic> GetAll()
        {
            try
            {
                return clientApp.GetAll();
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
                var client = clientApp.GetById(id);

                return (client != null) ? client : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("save")]
        public ActionResult<dynamic> Save([FromBody] DTOClient _client)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Client newClient = new Client
                {
                    name        = _client.name,
                    city        = _client.city,
                    document    = _client.document
                };

                clientApp.Add(newClient);

                return Ok(newClient);
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
                var client = clientApp.GetById(id);

                if (client == null)
                    return NotFound();

                clientApp.Remove(client);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult<dynamic> Update([FromRoute] int id, [FromBody] DTOClient _client)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Client client = clientApp.GetById(id);

                if (client == null)
                    return NotFound();

                client.name     = _client.name;
                client.document = _client.document;
                client.city     = _client.city;

                clientApp.Update(client);

                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
