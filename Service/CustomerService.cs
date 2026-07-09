using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Dto;
using crm_tgui.Repositories;

namespace crm_tgui.Service;

public class CustomerService(
    ICustomerRepo customerRepo,
    IUnitOfWork unitOfWork
) : ICustomerService

{
    public async Task<List<CustomerEntities>> GetAllCustomer()
    {
        var customers = await customerRepo.GetAllCustomer();

        return customers;
    }

    public async Task<CustomerEntities> GetACustomer(Guid Id)
    {
        var customer = await customerRepo.GetACustomer(Id);

        return customer;
    }

    public async Task<string> AddCustomer(CustomerBaseDto customerInfo)
    {
        var newCustomer = new CustomerEntities(
            firstName: customerInfo.FirstName,
            lastName: customerInfo.LastName,
            middleName: customerInfo.MiddleName ?? "",
            nationalId: customerInfo.NationalId
        );

        await customerRepo.AddCustomer(newCustomer);

        return "Customer added successfuly";
    }

    public async Task<string> UpdateCustomer(Guid Id, CustomerBaseDto customerInfo)
    {
        var customer = await customerRepo.GetACustomer(Id);

        customer.ChangeName(
            customerInfo.FirstName,
            customerInfo.MiddleName,
            customerInfo.LastName
            );

        unitOfWork.SaveChangesAsync();

        return "Customer's info updated successfully";
    }

    public async Task<string> DeleteCustomer (Guid Id)
    {
        await customerRepo.DeleteCustomer(Id);

        return "Customer deleted successfully";
    }
}
