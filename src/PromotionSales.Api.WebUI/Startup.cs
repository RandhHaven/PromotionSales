using PromotionSales.Api.Application;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Infrastructure;
using PromotionSales.Api.Infrastructure.Persistence;
using PromotionSales.Api.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PromotionSales.Api.WebUI.Filters;

namespace PromotionSales.Api.WebUI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication();

        services.AddInfrastructure(Configuration);

        services.AddSingleton<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddControllers();

        services.AddRazorPages();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddHealthChecks()
       .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddRazorPages();

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHealthChecks("/health");
        app.UseHttpsRedirection();
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Order Shop API");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();
        app.UseAuthentication();
        app.UseIdentityServer();
        app.UseAuthorization();

       
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{area=Promotion}/{controller=PromotionUI}/{action=Get}/{id?}");
        });
    }
}