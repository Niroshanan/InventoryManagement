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
    public class CategoryController : ControllerBase
    {
        private readonly IGenericServices _genericServices;
        public CategoryController(IGenericServices genericServices)
        {
            _genericServices = genericServices;
        }

        [Authorize(Roles = $"{SD.Operator},{SD.Manager},{SD.SuperAdmin}")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _genericServices.Categories.GetAllCategories();
            return Ok(categories);
        }


        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _genericServices.Categories.AddNewCategory(categoryDto);
                return Ok("Category Added Successfully");
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
                await _genericServices.Categories.DeleteCategory(id);
                return Ok("Category Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize(Roles = $"{SD.Manager},{SD.SuperAdmin}")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoryDTO categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _genericServices.Categories.UpdateCategory(id, categoryDto);
                return Ok("Category Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
