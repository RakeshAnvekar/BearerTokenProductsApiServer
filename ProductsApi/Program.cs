using ProductsApi.BusinessLogic;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.DBExecutor;
using ProductsApi.DBExecutor.Interfaces;
using ProductsApi.Mappers;
using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.ConnectionOption;
using ProductsApi.Repositories;
using ProductsApi.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);


#region DbExecutor
builder.Services.AddSingleton<IDbExecutor, DbExecutor>();
#endregion

#region Business Logic
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
#endregion

#region Repository
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
#endregion

#region Mappers
builder.Services.AddSingleton<IProductMapper, ProductMapper>();
builder.Services.AddSingleton<IUserMapper, UserMapper>();
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConnectionOption>(builder.Configuration.GetSection("ConnectionOption"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
