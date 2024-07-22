using InventoryManagement.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IGenericServices _genericServices;

        public SaleController(IGenericServices genericServices)
        {
            _genericServices = genericServices;
        }

    }
}
