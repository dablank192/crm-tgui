using System;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace crm_tgui.ViewModel;

public class Landing : View
{
    public Landing()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();

        var titleLabel = new Label()
        {
            Title = "WELCOME TO CUSTOMER RELATIONSHIP MANAGEMENT SERVICE",
            X = Pos.Center(),
            Y = Pos.Center()
        };

        var descLabel = new Label()
        {
            Title = "*Click here to start*",
            X = Pos.Center(),
            Y = Pos.Bottom(titleLabel) + 1
        };

        var startButton = new Button()
        {
            Title = "START",
            X = Pos.Center(),
            Y= Pos.Bottom(descLabel) + 1
        };

        Add(titleLabel, descLabel, startButton);
    }
}
