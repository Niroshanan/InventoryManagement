using Asp.Versioning;
using InventoryManagement.BLL.DTOs;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.BLL.Utility;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IGenericServices _genericServices;
        public PurchaseController(IGenericServices genericServices )
        {
            _genericServices = genericServices;
        }


        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
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
