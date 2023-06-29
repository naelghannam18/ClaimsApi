using Context;
using Core.Services.Contracts;
using Core.Services.Implementations;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace ClaimsApi;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddResponseCaching();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ClaimsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")), ServiceLifetime.Singleton);
        
        builder.Services.AddMemoryCache();

        builder.Services.AddScoped(typeof(GenericRepository<>));
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CachedGenericRepository<>));
        builder.Services.AddScoped<IDoctorsService, DoctorsService>();
        builder.Services.AddScoped<IHospitalsService, HospitalsService>();
        builder.Services.AddScoped<IClaimsService, ClaimsService>();
        builder.Services.AddScoped<IInsuredService, InsuredService>();
        builder.Services.AddTransient<IPdfService, PdfService>();
        builder.Services.AddTransient<IExcelService, ExcelService>();
    }
}
