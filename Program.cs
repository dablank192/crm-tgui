using crm_tgui.Extension;
using crm_tgui.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui.App;

var services = new ServiceCollection();
services.Service();
services.AddSingleton<MainWindow>();

var serviceProvider = services.BuildServiceProvider();

Application.Init();

var mainWindow = serviceProvider.GetRequiredService<MainWindow>();

Application.Run(mainWindow);

Application.Shutdown();