using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Dto;

namespace crm_tgui.Service;

public interface ICustomerService
{
    Task<List<CustomerEntities>> GetAllCustomer();
    Task<CustomerEntities> GetACustomer(Guid Id);
    Task<string> AddCustomer (CustomerBaseDto customerInfo);
    Task<string> UpdateCustomer (Guid Id, CustomerBaseDto customerInfo);
    Task<string> DeleteCustomer (Guid Id);
}
