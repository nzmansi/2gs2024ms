using Microsoft.AspNetCore.Mvc;

namespace gs2Gb93266Ez92955.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase{
    [HttpGet("/health")]
    public IActionResult Get(){
        return Ok("Serviço está funcionando.");
    }
}