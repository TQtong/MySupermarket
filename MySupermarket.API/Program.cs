using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySupermarket.API.Extensions;
using System.Reflection;
using WebApplication1;
using WebApplication1.Context;
using WebApplication1.Repository;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args).RegisterServices();

var appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? String.Empty;
var cfgPath = Path.Combine(appDir, "appsettings.json");

IConfigurationRoot? config = new ConfigurationBuilder()
    .AddJsonFile(cfgPath)
    .Build();	

builder.Services.AddDbContext<MyDbContext>(option =>
{
    var connetionString = config.GetConnectionString("create_user");
    option.UseSqlServer(connetionString);
});

builder.Services.AddUnitOfWork<MyDbContext>();
builder.Services.AddCustomRepository<User, UserRepository>();
builder.Services.AddTransient<ILoginService, LoginService>();

//Ìí¼ÓÓ³Éä¹ØÏµ£¨automapper£©
var autoMapperConfig = new MapperConfiguration(configure =>
{
    configure.AddProfile(new AutoMapperProFile());
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

var app = builder.Build().SetupMiddleware();

app.Run();


