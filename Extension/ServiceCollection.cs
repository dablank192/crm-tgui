using System;
using crm_tgui.Infrastructure;
using crm_tgui.Repositories;
using crm_tgui.Service;
using crm_tgui.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace crm_tgui.Extension;

public static class ServiceCollectionExtension
{
    public static void Service(this IServiceCollection collection)
    {
        collection.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddDebug();
        });
        
        
        //Create Db Path
        var dbPath = PathHelper.GetPath();


        //register db context
        collection.AddDbContextFactory<AppDbContext>(option =>
        {
            option.UseSqlite($"DataSource={dbPath}");
            option.LogTo(
                message => System.Diagnostics.Debug.WriteLine(message),
                Microsoft.Extensions.Logging.LogLevel.Information
            );
        });


        //register service
        collection.AddTransient<IUnitOfWork, UnitOfWork>();
        collection.AddTransient<ICustomerRepo, CustomerRepo>();
        collection.AddTransient<ICustomerService, CustomerService>();


        //register view
        collection.AddTransient<Landing>();
        collection.AddTransient<AddCustomerView>();
    }
}
