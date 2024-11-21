using StackExchange.Redis;

namespace gs2Gb93266Ez92955.Services;

public class RedisCacheService{
    private readonly IDatabase _cache;

    public RedisCacheService(){
        var redis = ConnectionMultiplexer.Connect("localhost");
        _cache = redis.GetDatabase();
    }

    public async Task<string?> Obter(string chave){
    return await _cache.StringGetAsync(chave);
    }

    public async Task Adicionar(string chave, string valor, TimeSpan expiracao){
        await _cache.StringSetAsync(chave, valor, expiracao);
    }
}