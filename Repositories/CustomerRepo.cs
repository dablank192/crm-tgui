using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Terminal.Gui.Tracing;

namespace crm_tgui.Repositories;

public class CustomerRepo(
    IDbContextFactory<AppDbContext> dbFactory
)
{
    public async Task<List<CustomerEntities>> GetAllCustomer()
    {
        using var dbContext = dbFactory.CreateDbContext();
    
        var customer = await dbContext.Customer.ToListAsync();

        return customer;
    }
}
