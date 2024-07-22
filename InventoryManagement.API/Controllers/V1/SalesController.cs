using InventoryManagement.BLL.DTOs;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IGenericServices _genericServices;

        public SalesController(IGenericServices genericServices)
        {
            _genericServices = genericServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaleDTO saleDTO)
        {
            try
            {
                await _genericServices.Sales.AddSale(saleDTO);
                return Ok("Sales Updated Successfully");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
