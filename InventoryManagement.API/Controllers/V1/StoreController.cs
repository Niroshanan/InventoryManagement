using Asp.Versioning;
using InventoryManagement.BLL.DTOs;
using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.BLL.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IGenericServices _genericService;

        public StoreController(IGenericServices GenericServices)
        {
            _genericService = GenericServices;
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            try
            {
                var stores = await _genericService.Stores.GetAllStores();
                return Ok(stores);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the server");
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPost]
        public async Task<IActionResult> AddNewStore([FromBody] StoreDto storeDto)
        {
            try
            {
                var result = await _genericService.Stores.AddNewStore(storeDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditStore(Guid id, [FromBody] StoreDto storeDto)
        {
            try
            {
                await _genericService.Stores.EditStore(id, storeDto);
                return Ok("Store updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            try
            {
                var result = await _genericService.Stores.DeleteStore(id);
                return Ok($"{result} Items Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet("RemainingStock")]
        public async Task<IActionResult> GetRemainingStockCount([FromQuery] Guid? id = null)
        {
            try
            {
                var store = await _genericService.Stores.GetRemainingStock(id);
                return Ok(store);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
