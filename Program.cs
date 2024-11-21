using gs2Gb93266Ez92955.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "gs2Gb93266Ez92955", Version = "v1" });
});

builder.Services.AddSingleton<MongoService>();
builder.Services.AddSingleton<RedisCacheService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "gs2Gb93266Ez92955 v1");
    c.RoutePrefix = string.Empty;
});

app.UseRouting();
app.MapControllers();

app.Run();