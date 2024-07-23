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
    public class ProductController : ControllerBase
    {
        private readonly IGenericServices _genericServices;
        public ProductController(IGenericServices genericServices)
        {
            _genericServices = genericServices;
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _genericServices.Products.GetAllProducts();
            return Ok(products);
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _genericServices.Products.AddProduct(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _genericServices.Products.DeleteProdcut(id);
                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProductDTO product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _genericServices.Products.UpdateProduct(id, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
