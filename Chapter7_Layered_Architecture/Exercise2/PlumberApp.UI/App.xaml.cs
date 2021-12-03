using PlumberApp.Infrastructure.Storage;
using System;
using System.IO;
using System.Windows;

namespace PlumberApp.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            String path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PlumberApp");

            WorkloadFileRepository workload = new WorkloadFileRepository(path);

            MainWindow mainWindow = new MainWindow(workload);
            mainWindow.Show();

            //TODO: wiring, instantiate MainWindow and show it.
        }
    }
}
