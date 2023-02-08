using Clientes_API.Entities;
using Clientes_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clientes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        IAddressesService _addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            _addressesService = addressesService;
        }

        // GET: api/<AddressesController>
        [HttpGet("{clienteId}")]
        public IActionResult Get(int clienteId)
        {
            try
            {
                var clientes = _addressesService.GetAddressesList(clienteId);

                if (clientes == null)
                    return NotFound();

                return Ok(clientes);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST api/<AddressesController>
        [HttpPost]
        public IActionResult Post([FromBody] Address[] items)
        {
            try
            {
                var model = _addressesService.SaveAddress(items.ToList());

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<AddressesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response = _addressesService.DeleteAddress(id);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
