using Microsoft.AspNetCore.Mvc;
using gs2Gb93266Ez92955.Services;
using gs2Gb93266Ez92955.Models;

namespace gs2Gb93266Ez92955.Controllers;

[ApiController]
[Route("[controller]")]
public class ConsumoController : ControllerBase{
    private readonly MongoService _mongoService;
    private readonly RedisCacheService _redisCacheService;

    public ConsumoController(MongoService mongoService, RedisCacheService redisCacheService)
    {
        _mongoService = mongoService;
        _redisCacheService = redisCacheService;
    }

    [HttpPost("/consumo")]
    public async Task<IActionResult> Post([FromBody] Consumo consumo){
        await _mongoService.Adicionar(consumo);
        return StatusCode(201);
    }

    [HttpGet("/consumo")]
    public async Task<IActionResult> Get(){
        var cacheDados = await _redisCacheService.Obter("consumo");
        
        if (!string.IsNullOrEmpty(cacheDados)){
            return Ok(cacheDados);
        }

        var consumos = await _mongoService.ObterTodos();
        await _redisCacheService.Adicionar("consumo", System.Text.Json.JsonSerializer.Serialize(consumos), TimeSpan.FromMinutes(5));

        return Ok(consumos);
    }
}