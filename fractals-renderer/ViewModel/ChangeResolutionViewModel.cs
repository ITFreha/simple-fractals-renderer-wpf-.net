using fractals_renderer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace fractals_renderer.ViewModel
{
    public class ChangeResolutionViewModel
    {
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }

        public ICommand ChangeResolutionCommand { get; set; }

        private Fractal fractal;

        public ChangeResolutionViewModel()
        {
            fractal = ((App)Application.Current).Fractal;
            ResolutionWidth = fractal.Bitmap.PixelWidth;
            ResolutionHeight = fractal.Bitmap.PixelHeight;
            ChangeResolutionCommand = new RelayCommand((arg) => ChangeResolutionMethod());
        }

        private void ChangeResolutionMethod()
        {
            fractal.NewBitmap(ResolutionWidth, ResolutionHeight);
            fractal.RenderBitmap();
        }
    }
}
