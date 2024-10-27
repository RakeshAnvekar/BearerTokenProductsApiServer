using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ProductsApi.BusinessLogic;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.DBExecutor;
using ProductsApi.DBExecutor.Interfaces;
using ProductsApi.Mappers;
using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.ConnectionOption;
using ProductsApi.Models.User;
using ProductsApi.Repositories;
using ProductsApi.Repositories.Interfaces;
using static Azure.Core.HttpHeader;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);


#region DbExecutor
builder.Services.AddSingleton<IDbExecutor, DbExecutor>();
#endregion

#region Business Logic
builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IUserLogic, UserLogic>();
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
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


#region Jwt Token Settings

builder.Services.AddAuthentication(options =>
{
   /* The DefaultAuthenticateScheme is a setting that determines 
    how the application will attempt to authenticate incoming requests by default.
    When a request comes in, this setting tells the application 
    which authentication method to use to verify the user's identity*/
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;

    /*When a user tries to access a protected resource (like a profile page or API endpoint)
    without providing a valid JWT token,
    the server needs to tell them that they need to authenticate.
    This is where the challenge scheme comes into play.*/
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        //This property specifies how the incoming JWT tokens will be validated
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {

            //When a user tries to access a protected resource, they send a JWT token with their request
            ///application checks the iss claim in the incoming token
            //If the iss claim matches the ValidIssuer that you specified (e.g., "MyAuthServer"),
            //then the token is considered valid for the issuer.
            ValidateIssuer = true,
            ValidateAudience = true,
            //Application checks whether the current time is within the valid time frame specified by the exp claim.
            //If the token is expired, it will be considered invalid.
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,//Matces the signature of the token with computed signature

            //Validating both the issuer and audience,
            //your application ensures that the token is not only from a trusted source but also intended for your specific application.
            //This helps prevent token misuse across different applications
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience= builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

    });
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
