using fractals_renderer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace fractals_renderer.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        public int ColorKoef { get; set; }
        public int IterationsCount { get; set; }
        public int ScaleKoef { get; set; }

        private Fractal fractal;

        public ICommand SaveFractalSettingsCommand { get; set; }

        public SettingsViewModel()
        {
            fractal = ((App)Application.Current).Fractal;
            ColorKoef = fractal.ColorKoef;
            IterationsCount = fractal.IterationsCount;
            ScaleKoef = fractal.ScaleKoef;
            SaveFractalSettingsCommand = new RelayCommand((arg) => SaveFractalSettingsMethod());
        }

        private void SaveFractalSettingsMethod()
        {
            fractal.IterationsCount = IterationsCount;
            fractal.ScaleKoef = ScaleKoef;
            fractal.ColorKoef = ColorKoef;
            fractal.RenderBitmap();
        }
    }
}
