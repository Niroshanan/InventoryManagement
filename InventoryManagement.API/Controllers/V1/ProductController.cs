using InventoryManagement.BLL.Services.Interfaces;
using InventoryManagement.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericServices _genericServices;
        private readonly IUnitOfWork _genericRepository;
        public ProductController(IGenericServices genericServices, IUnitOfWork genericRepository)
        {
            _genericServices = genericServices;
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _genericServices.Products.GetAllProducts();
            return Ok(products);
        }
    }
}
