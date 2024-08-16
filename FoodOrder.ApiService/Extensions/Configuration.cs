using Carter;

namespace FoodOrder.ApiService.Extensions
{
    public static class Configuration
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer()
                
                .AddSwaggerGen();

            // Add service defaults & Aspire components.
            builder.AddServiceDefaults();
            // Add services to the container.
            builder.Services.AddProblemDetails();
        }
        public static void RegisterMiddlewares(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();
            // Configure the HTTP request pipeline.
            app.UseExceptionHandler();
        }
    }
}
