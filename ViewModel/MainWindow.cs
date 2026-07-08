using System;
using crm_tgui.Extension;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui.App;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace crm_tgui.ViewModel;

public class MainWindow : Window
{
    private View _contentContainer;
    private View _currentView;
    private IServiceProvider _serviceProvider;

    public MainWindow(IServiceProvider serviceProvider) : base()
    {
        _serviceProvider = serviceProvider;

        var menu = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem(Title = "Menu", new MenuItem[]
            {
                new MenuItem("Home", "", () => NavigateTo<Landing>()),
                new MenuItem("Exit", "", () => Application.RequestStop())
            })
        });

        Add(menu);

        _contentContainer = new View
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        Add(_contentContainer);
    }

    public void NavigateTo(View newView)
    {
        if(_currentView != null)
        {
            if(_currentView.GetType() == newView.GetType())
            {
                newView.Dispose();
                return;
            }

        _contentContainer.Remove(_currentView);

        _contentContainer.Dispose();
        }

        _currentView = newView;

        _currentView.Width = Dim.Fill();
        _currentView.Height = Dim.Fill();

        _contentContainer.Add(_currentView);
    }

    public void NavigateTo<T>() where T : View
    {
        var newView = _serviceProvider.GetRequiredService<T>();

        NavigateTo(newView);
    }
}
