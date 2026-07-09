using System;

namespace crm_tgui.Domain.Entities;

public static class CustomerStatus
{
    public const string Active = "A";
    public const string InActive = "I";
}

public class CustomerEntities
{
    public Guid Id {get; set;}
    public int CustomerId {get; private set;}
    public string FirstName {get; private set;}
    public string? MiddleName {get; private set;}
    public string LastName {get; private set;}
    public string? NationalId {get; private set;}
    public string Status {get; set;}
    public DateTime CreatedAt {get; set;}
    
    protected CustomerEntities() {}
    
    public CustomerEntities(string firstName, string lastName, string nationalId, string? middleName = null) 
    {
        if (string.IsNullOrEmpty(firstName) | string.IsNullOrEmpty(lastName))
        {
            throw new Exception("Customer Name field can not be empty");
        }

        if(middleName != null)
        {
            MiddleName = middleName;
        }

        int.TryParse(nationalId, out int customerId);

        if(customerId <= 10) throw new Exception("National ID can not be less than 10 digit number");

        CustomerId = Random.Shared.Next(100000, 1000000);
        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        Status = CustomerStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    public void ChangeNationalId (string newNationalId)
    {
        int.TryParse(newNationalId, out int customerId);
        if(customerId <= 10) throw new Exception("National ID can not be less than 10 digit number");

        NationalId = newNationalId;
    }

    public void DeactiveCustomer()
    {
        Status = CustomerStatus.InActive;
    }

    public void ChangeName(string? newFirstName = null, string? newMiddleName = null, string? newLastName = null)
    {
        if (string.IsNullOrEmpty(newFirstName) | string.IsNullOrEmpty(newLastName))
        {
            throw new Exception("Customer Name field can not be empty");
        }
        
        FirstName = !string.IsNullOrWhiteSpace(newFirstName) ? newFirstName : FirstName;
        MiddleName = newMiddleName ?? MiddleName;
        LastName = !string.IsNullOrWhiteSpace(newLastName) ? newLastName : LastName;
    }
}
