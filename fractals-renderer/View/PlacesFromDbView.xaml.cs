using fractals_renderer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fractals_renderer.View
{
    /// <summary>
    /// Логика взаимодействия для GoToThePlaceFromDbView.xaml
    /// </summary>
    public partial class PlacesFromDbView : Window
    {
        public PlacesFromDbView()
        {
            InitializeComponent();
        }

        private void RenderPlace(object sender, MouseButtonEventArgs e)
        {
            ((PlacesFromDbViewModel)this.DataContext).RenderPlaceCommand.Execute(sender);
        }
    }
}
