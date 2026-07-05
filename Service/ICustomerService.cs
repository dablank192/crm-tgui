using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Dto;

namespace crm_tgui.Service;

public interface ICustomerService
{
    Task<List<CustomerEntities>> GetAllCustomer();
    Task<CustomerEntities> GetACustomer(Guid Id);
    Task<string> AddCustomer (string firstName, string lastName, int nationalId, string? middleName = null);
    Task<string> UpdateCustomer (Guid Id, CustomerBaseDto customerInfo);
    Task<string> DeleteCustomer (Guid Id);
}
