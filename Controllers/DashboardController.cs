using Clientes_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clientes_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        // GET: api/<DashboardController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dashboard = _dashboardService.GetDashboard();

                if (dashboard == null)
                    return NotFound();

                return Ok(dashboard);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
