using fractals_renderer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fractals_renderer.View
{
    public static class ViewRequest
    {
        public static void RequestGoToThePlaceByCenterAndView(PlaceByCenterAndView viewModel)
        {
            SetDataContextAndShow(new SetViewView(), viewModel);
        }

        public static void RequestOpenChangeResolution(ChangeResolutionViewModel viewModel)
        {
            SetDataContextAndShow(new ChangeResolutionView(), viewModel);
        }

        public static void RequestOpenSavePlace(SavePlaceToDbViewModel viewModel)
        {
            SetDataContextAndShow(new SavePlaceToDbView(), viewModel);
        }

        public static void RequestGoToThePlaceFromDb(PlacesFromDbViewModel viewmodel)
        {
            SetDataContextAndShow(new PlacesFromDbView(), viewmodel);
        }

        public static void RequestMainWindow(MainWindowViewModel viewmodel)
        {
            Application.Current.MainWindow = new MainWindow();
            SetDataContextAndShow(Application.Current.MainWindow, viewmodel);
        }

        public static void RequestOpenSettings(SettingsViewModel viewModel)
        {
            SetDataContextAndShow(new SettingsView(), viewModel);
        }

        private static void SetDataContextAndShow(Window view, object dataContext)
        {
            if (view != Application.Current.MainWindow)
            {
                view.Owner = Application.Current.MainWindow;
                view.Closed += (s, e) => { Application.Current.MainWindow.Focus(); };
            }
            view.DataContext = dataContext;
            view.Show();
        }
    }
}
