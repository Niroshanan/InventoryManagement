using Asp.Versioning;
using InventoryManagement.BLL.DTOs;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.BLL.Utility;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagement.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IGenericServices _genericServices;

        public SalesController(IGenericServices genericServices)
        {
            _genericServices = genericServices;
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
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

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet("GetAllSales")]
        public async Task<IActionResult> Get()
        {
            var sales = await _genericServices.Sales.GetAllSales();
            return Ok(sales);
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet("GetSalesByStore/{storeId}")]
        public async Task<IActionResult> GetSalesByStore(Guid storeId)
        {
            var sales = await _genericServices.Sales.GetSalesByStore(storeId);
            return Ok(sales);
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet("GetSalesByProduct/{productId}")]
        public async Task<IActionResult> GetSalesByProduct(Guid productId)
        {
            var sales = await _genericServices.Sales.GetSalesByProduct(productId);
            return Ok(sales);
        }
    }
}
