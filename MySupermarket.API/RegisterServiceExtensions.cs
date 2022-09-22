using Microsoft.OpenApi.Models;

namespace MySupermarket.API
{
    public static class RegisterServiceExtensions
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Create_User.Api", Version = "v1" });
            });

            return builder;
        }
    }
}
