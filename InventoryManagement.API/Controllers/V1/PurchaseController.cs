using InventoryManagement.BLL.DTOs;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IGenericServices _genericServices;
        public PurchaseController(IGenericServices genericServices )
        {
            _genericServices = genericServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                await _genericServices.Purchase.AddPurchase(purchaseDTO);
                return Ok("Purchase updated successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
