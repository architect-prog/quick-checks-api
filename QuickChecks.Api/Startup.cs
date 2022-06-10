using ArchitectProg.Kernel.Extensions.Exceptions;
using ArchitectProg.WebApi.Extensions.Attributes;
using ArchitectProg.WebApi.Extensions.Filters;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuickChecks.Api.Extensions;
using QuickChecks.Api.Modules;
using QuickChecks.Persistence.Settings;

namespace QuickChecks.Api;

public class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(new ProducesUnauthorizedAttribute());
            options.Filters.Add(new BadRequestOnExceptionFilter(typeof(ValidationException)));
            options.Filters.Add(new NotFoundOnExceptionFilter(typeof(ResourceNotFoundException)));
        }).AddControllersAsServices();

        services.AddOptions();

        services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
        services.AddSwaggerGen();
    }

    public void ConfigureContainer(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule<MappingModule>();
        containerBuilder.RegisterModule<FactoryModule>();
        containerBuilder.RegisterModule<ServiceModule>();
        containerBuilder.RegisterModule<ValidationModule>();
        containerBuilder.RegisterModule<InfrastructureModule>();
        containerBuilder.RegisterModule<PersistenceModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.ApplyMigrations();

        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}