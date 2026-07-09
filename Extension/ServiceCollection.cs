using System;
using crm_tgui.Infrastructure;
using crm_tgui.Repositories;
using crm_tgui.Service;
using crm_tgui.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace crm_tgui.Extension;

public static class ServiceCollectionExtension
{
    public static void Service(this IServiceCollection collection)
    {

        //Create Db Path
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var appPath = Path.Combine(path, "crm-tgui");

        if (!Directory.Exists(appPath))
        {
            Directory.CreateDirectory(appPath);
        }

        var dbPath = Path.Combine(appPath, "crm-tgui.db");


        //register db context
        collection.AddDbContextFactory<AppDbContext>(option =>
        {
            option.UseSqlite(dbPath);
        });


        //register service
        collection.AddTransient<IUnitOfWork, UnitOfWork>();
        collection.AddTransient<ICustomerRepo, CustomerRepo>();
        collection.AddTransient<ICustomerService, CustomerService>();


        //register view
        collection.AddTransient<Landing>();
        collection.AddTransient<AddCustomer>();
    }
}
