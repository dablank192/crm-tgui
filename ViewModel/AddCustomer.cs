using System;
using crm_tgui.Domain.Entities;
using crm_tgui.Dto;
using crm_tgui.Service;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace crm_tgui.ViewModel;

[Obsolete]
public class AddCustomer : View
{
    private readonly ICustomerService _customerService;
    private TextField _txtFirstName;
    private TextField _txtMiddleName;
    private TextField _txtLastName;
    private TextField _nationalId;
    private Button _btnSubmit;
    

    public AddCustomer(ICustomerService customerService)
    {
        _customerService = customerService;

        Width = Dim.Fill();
        Height = Dim.Fill();

        var frame = new FrameView()
        {
            Title = "New Customer",
            X = Pos.Center(),
            Y = Pos.Center(),
            Width = Dim.Percent(50),
            Height = 15
        };

        var firstNameLbl = new Label()
        {
            Title = "First Name:",
            X = 1,
            Y = 1
        };

        _txtFirstName = new TextField()
        {
            X = 20,
            Y = 1,
            Width = Dim.Fill() - 1
        };

        var middleNameLbl = new Label()
        {
            Title = "MiddleName:",
            X = 1,
            Y = Pos.Bottom(firstNameLbl) + 1
        };
        _txtMiddleName = new TextField()
        {
            X = 20,
            Y = Pos.Top(middleNameLbl),
            Width = Dim.Fill() - 1 
        };

        var lastName = new Label()
        {
            Title = "Last Name:",
            X = 1,
            Y = Pos.Bottom(middleNameLbl) + 1
        };
        _txtLastName = new TextField()
        {
            X = 20,
            Y = Pos.Top(lastName),
            Width = Dim.Fill() - 1 
        };

        var nationalId = new Label()
        {
            Title = "Identity Number:",
            X = 1,
            Y = Pos.Bottom(lastName) + 1
        };
        _nationalId = new TextField()
        {
            X = 20,
            Y = Pos.Top(nationalId),
            Width = Dim.Fill() - 1
        };

        _btnSubmit = new Button()
        {
            Title = "Add Customer",
            X = Pos.Center(),
            Y = 9
        };

        _btnSubmit.Accepting += async (s, a) => await OnSubmitClick();

        frame.Add(firstNameLbl, _txtFirstName, middleNameLbl, _txtMiddleName, lastName, _txtLastName, nationalId, _nationalId, _btnSubmit);
        Add(frame);

        Initialized += (sender, args) => _txtFirstName.SetFocus();
    }

    [Obsolete]
    public async Task OnSubmitClick()
    {
        var firstName = _txtFirstName.Text.ToString();
        var middleName = _txtMiddleName.Text.ToString()?? "";
        var lastName =  _txtLastName.Text.ToString();
        var nationalId = _nationalId.Text.ToString();

        if( string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            MessageBox.ErrorQuery(
                Application.Instance,
                title: "ERROR",
                message: "Required field can not be null",
                buttons: "OK"
            );

            return;
        }

        _btnSubmit.Enabled = false;
        _btnSubmit.Text = "Loading...";

        var newCustomer = new CustomerBaseDto(
            FirstName: firstName,
            MiddleName: middleName,
            LastName: lastName,
            NationalId: nationalId
        );

        await Task.Run(async () => await ExecuteAsync(newCustomer));
    }


    [Obsolete]
    public async Task ExecuteAsync(CustomerBaseDto customerInfo)
    {
        try
        {
            await _customerService.AddCustomer(customerInfo);

            Application.Invoke(() =>
            {
                MessageBox.Query(
                    Application.Instance,
                    title:  "Success",
                    message: "Customer added successfully",
                    buttons: "OK"
                );
                _txtFirstName.Text = "";
                _txtMiddleName.Text = "";
                _txtLastName.Text = "";
                _nationalId.Text = "";
                _btnSubmit.Enabled = true;

                SetNeedsDraw();
            });
        }
        catch(Exception ex)
        {
            Application.Invoke(() =>
            {
                MessageBox.ErrorQuery(
                    Application.Instance,
                    title: "ERROR",
                    message: $"An Unknown error has occur{ex}",
                    buttons: "OK"
                );
                _btnSubmit.Enabled = true;

                SetNeedsDraw();
            });
        }
    }
}
