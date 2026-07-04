using System;
using crm_tgui.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace crm_tgui.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option){}

    public DbSet<CustomerEntities> Customer {get; set;}

    public void Configure (ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
