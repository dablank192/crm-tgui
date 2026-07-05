using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace crm_tgui.Repositories;

public class CustomerRepo(
    IDbContextFactory<AppDbContext> dbFactory
) : ICustomerRepo
{
    public async Task<List<CustomerEntities>> GetAllCustomer()
    {
        using var dbContext = dbFactory.CreateDbContext();
    
        var customer = await dbContext.Customer.ToListAsync();

        return customer;
    }

    public async Task<CustomerEntities> GetACustomer(Guid Id)
    {
        using var dbContext = dbFactory.CreateDbContext();

        var customer = await dbContext.Customer
        .FirstOrDefaultAsync(t => t.Id == Id)
        ?? throw new Exception("Customer not found");

        return customer;
    }

    public async Task AddCustomer(CustomerEntities newCustomer)
    {
        using var dbContext = dbFactory.CreateDbContext();

        dbContext.Customer.Add(newCustomer);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteCustomer(Guid Id)
    {
        using var dbContext = dbFactory.CreateDbContext();
        var customer = await dbContext.Customer.FindAsync(Id)
        ?? throw new Exception("Customer not found");

        dbContext.Remove(customer);
        await dbContext.SaveChangesAsync();
    }
}
