using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySupermarket.API;
using MySupermarket.API.Context;
using MySupermarket.API.Extensions;
using MySupermarket.API.Repository;
using MySupermarket.API.Service.Music;
using MySupermarket.API.UnitOfWork;
using System.Reflection;

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

//注册仓储
builder.Services.AddCustomRepository<User, UserRepository>();
builder.Services.AddCustomRepository<MusicInfo, MusicInfoRepository>();

//注册自定义服务
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IMusicInfoService, MusicInfoService>();

//添加映射关系（automapper）
var autoMapperConfig = new MapperConfiguration(configure =>
{
    configure.AddProfile(new AutoMapperProFile());
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

var app = builder.Build().SetupMiddleware();

app.Run();


