using fractals_renderer.Model;
using fractals_renderer.Service;
using fractals_renderer.View;
using fractals_renderer.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace fractals_renderer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MainWindow mainWindow { get; set; }
        public Fractal Fractal { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewRequest.RequestMainWindow(new MainWindowViewModel(new DialogService(), new FileService()));
        }
    }
}
