using MongoDB.Driver;
using gs2Gb93266Ez92955.Models;

namespace gs2Gb93266Ez92955.Services;

public class MongoService{
    private readonly IMongoCollection<Consumo> _consumoCollection;

    public MongoService(){
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("EnergiaDB");
        _consumoCollection = database.GetCollection<Consumo>("Consumos");
    }

    public async Task<List<Consumo>> ObterTodos(){
        return await _consumoCollection.Find(c => true).ToListAsync();
    }

    public async Task Adicionar(Consumo consumo){
        await _consumoCollection.InsertOneAsync(consumo);
    }
}