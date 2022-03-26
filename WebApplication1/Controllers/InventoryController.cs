using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {

        private readonly ILogger<InventoryController> _logger;
        private readonly IProductInventoryInterface _productInventoryInterface;

        public InventoryController(ILogger<InventoryController> logger,IProductInventoryInterface productInventoryInterface)
        {
            _productInventoryInterface = productInventoryInterface;
            _logger = logger;
        }

        [HttpGet]
        public IList<RequestInventory> Get()
        {
            var result = _productInventoryInterface.GetProductInventory();
            return result.ToList();
        }
    }
}
