using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebStore.Infrastructure;
using WebStore.Infrastructure.Services;
using WebStore.Interfaces.Infrastructure;

namespace WebStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(SimpleActionFilter)); // подключение по типу

                // альтернативный вариант подключения
                options.Filters.Add(new SimpleActionFilter()); // подключение по объекту
            });

            // Добавляем разрешение зависимости
            services.AddSingleton<IEmployeesService, InMemoryEmployeesService>();
            //services.AddScoped<IEmployeesService, InMemoryEmployeesService>();
            //services.AddTransient<IEmployeesService, InMemoryEmployeesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            var helloString = _configuration["CustomHelloWorld"];
            //var helloString = _configuration["Logging:LogLevel:Default"];

            app.UseWelcomePage("/welcome");

            app.UseMiddleware<TokenMiddleware>();

            UseMiddlewareSample(app);

            app.Map("/index", CustomIndexHandler);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute(); // краткий аналог
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
// https://localhost:44317/    home            /index
// https://localhost:44317/
                // Маршрут по умолчанию состоит из трёх частей разделённых “/”
                // Первой частью указывается имя контроллера,
                // второй - имя действия (метода) в контроллере,
                // третей - опциональный параметр с именем “id”
                // Если часть не указана - используются значения по умолчанию:
                // для контроллера имя “Home”,
                // для действия - “Index”


                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync(helloString);
                //});
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("No handler found for this request...");
            });
        }

        private void CustomIndexHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("response to /Index URL...");
            });
        }

        private void UseMiddlewareSample(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                bool isError = false;
                // ...
                if (isError)
                {
                    await context.Response
                        .WriteAsync("Error occured. You're in custom pipeline module...");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }

    }
}
