using System;
using crm_tgui.Domain.Entities;

namespace crm_tgui.Repositories;

public interface ICustomerRepo
{
    Task<List<CustomerEntities>> GetAllCustomer();
    Task<CustomerEntities> GetACustomer(Guid Id);
    Task AddCustomer(CustomerEntities newCustomer);
    Task DeleteCustomer(Guid Id);
}
