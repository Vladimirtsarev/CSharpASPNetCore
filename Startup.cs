using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapDefaultControllerRoute(); // ������� ������
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // https://localhost:44317/    home            /index
                // https://localhost:44317/
                // ������� �� ��������� ������� �� ��� ������ ���������� �/�
                // ������ ������ ����������� ��� �����������,
                // ������ - ��� �������� (������) � �����������,
                // ������ - ������������ �������� � ������ �id�
                // ���� ����� �� ������� - ������������ �������� �� ���������:
                // ��� ����������� ��� �Home�,
                // ��� �������� - �Index�


                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync(helloString);
                //});
            });
        }
    }
}
