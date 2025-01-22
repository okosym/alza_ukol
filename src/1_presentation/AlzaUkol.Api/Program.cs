using AlzaUkol.Api.Extras;
using AlzaUkol.Application.Dummy;
using AlzaUkol.Application.Orders;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AlzaUkol.Api;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        __RegisterServices(builder.Services);

        WebApplication app = builder.Build();
        __RegisterMiddlewares(app);

        app.Run();
    }

    private static void __RegisterServices(IServiceCollection services)
    {
        // Mvc
        _MvcSettings.AddMvcServices(services);
        MyValidationResponse.TransformValidationResponse(services);

        // Swagger
        _SwaggerSettings.AddSwaggerServices(services);

        // Facades
        services.AddScoped<DummyFacade>();
        services.AddScoped<OrdersFacade>();

        // Repositories
        services.AddScoped<OrdersRepository>();
    }

    private static void __RegisterMiddlewares(IApplicationBuilder app)
    {
        //app.UseHttpsRedirection();
        //app.UseAuthorization();

        // Mvc
        _MvcSettings.UseMvcMiddleware(app);
        
        // Swagger
        _SwaggerSettings.UseSwaggerMiddleware(app);
    }

    private static class _MvcSettings
    {
        // services
        public static void AddMvcServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<MyExceptionFilterAttribute>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter()); // converts enums as strings
            });
        }

        // middlewares
        public static void UseMvcMiddleware(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }

    private static class _SwaggerSettings
    {
        // services
        public static void AddSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AlzaUkol API", Version = "v1" });
            });
        }

        // middlewares
        public static void UseSwaggerMiddleware(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "AlzaUkol API V1");
                options.RoutePrefix = "help";
                options.DefaultModelsExpandDepth(-1);
                options.DocExpansion(DocExpansion.List);
                options.DefaultModelRendering(ModelRendering.Example);
            });
        }
    }
}