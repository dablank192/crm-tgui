using System;
using crm_tgui.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace crm_tgui.Repositories;

public interface IUnitOfWork
{
    void SaveChangesAsync();
}
public class UnitOfWork(
    IDbContextFactory<AppDbContext> dbFactory
) : IUnitOfWork

{
    public void SaveChangesAsync()
    {
        using var dbContext = dbFactory.CreateDbContext();
        dbContext.SaveChangesAsync();
    }    
}
