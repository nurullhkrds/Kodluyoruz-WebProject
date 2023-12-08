using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/*
builder.Services.AddSingleton<ICarService,CarManager>();
builder.Services.AddSingleton<IBrandService, BrandManager>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<ICustomerService, CustomerManager>();
builder.Services.AddSingleton<IColorService, ColorManager>();
builder.Services.AddSingleton<IRentalService, RentalManager>();

builder.Services.AddSingleton<ICarDal, EfCar>();
builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
builder.Services.AddSingleton<IUsersDal, EfUsersDal>();
builder.Services.AddSingleton<ICustomerDal, EfCustomersDal>();
builder.Services.AddSingleton<IColorDal, EfColorDal>();
builder.Services.AddSingleton<IRentalsDal, EfRentalsDal>();

*/


//IoC Containers --> Autofac implementation
IHostBuilder hostBuilder = builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(options =>
    options.RegisterModule(new AutofacBusinessModule())
));


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
ServiceTool.Create(builder.Services);






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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