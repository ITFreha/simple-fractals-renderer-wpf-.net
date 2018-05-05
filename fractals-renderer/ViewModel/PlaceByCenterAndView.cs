using fractals_renderer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace fractals_renderer.ViewModel
{
    public class PlaceByCenterAndView
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double W { get; set; }

        public ICommand SetViewCommand { get; set; }

        public PlaceByCenterAndView()
        {
            SetViewCommand = new RelayCommand((arg) => SetViewMethod());
        }

        public void SetViewMethod()
        {
            Fractal fractal = ((App)Application.Current).Fractal;
            double h = W / fractal.AspectRatio;
            PlaneView view = new PlaneView(CenterX - W / 2, CenterY + h / 2, W, h);
            fractal.SetNewView(view);
            fractal.RenderBitmap();
        }
    }
}
