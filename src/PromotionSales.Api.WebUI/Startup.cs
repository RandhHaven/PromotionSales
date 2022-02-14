using PromotionSales.Api.Application;
using PromotionSales.Api.Application.Common.Interfaces;
using PromotionSales.Api.Infrastructure;
using PromotionSales.Api.Infrastructure.Persistence;
using PromotionSales.Api.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PromotionSales.Api.WebUI.Filters;
using Microsoft.OpenApi.Models;

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

        services.AddHealthChecks()
       .AddDbContextCheck<ApplicationDbContext>();

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddSwaggerGen(swaggerConfiguration =>
        {
            swaggerConfiguration.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Core API",
                Description = "Core API - Promotion Api",
            });

            swaggerConfiguration.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Bearere <access-token>",
            });

            swaggerConfiguration.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
        });

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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Promotions API");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();
        app.UseAuthentication();
        //app.UseIdentityServer();
        app.UseAuthorization();
               
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{area=Promotion}/{controller=PromotionUI}/{action=Get}/{id?}");
        });
    }
}