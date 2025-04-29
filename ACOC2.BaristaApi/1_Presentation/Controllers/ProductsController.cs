using ACOC2.Shared.Contracts.Barista;
using Microsoft.AspNetCore.Mvc;

namespace ACOC2.BaristaApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("menu")]
    public IActionResult GetMenu()
    {
        return Ok(new CoffeeMenuResponse());
    }
}
