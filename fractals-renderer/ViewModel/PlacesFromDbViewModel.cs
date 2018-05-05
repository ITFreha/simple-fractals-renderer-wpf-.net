using fractals_renderer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace fractals_renderer.ViewModel
{
    public class PlacesFromDbViewModel : BaseViewModel
    {
        private List<Place> places;
        public List<Place> Places
        {
            get { return places; }
            set { places = value; OnPropertyChanged("Places"); }
        }

        public ICommand RenderPlaceCommand { get; set; }

        public PlacesFromDbViewModel()
        {
            Places = new List<Place>() { new Place { Name = "Default", CenterX = -0.5, CenterY = 0, W = 3, IterationsCount = 250 } };

            RenderPlaceCommand = new RelayCommand((sender) => RenderPlaceMethod(sender));
            Task.Run(() =>
            {
                using (AppDbContext db = new AppDbContext())
                {
                    List<Place> list = db.Places.ToList();
                    if (list.Count != 0)
                        Places = db.Places.ToList();
                }
            });
        }

        private void RenderPlaceMethod(object sender)
        {
            Fractal fractal = ((App)Application.Current).Fractal;
            Place place = (Place)(sender as ListBoxItem).DataContext;
            PlaneView view = place.ToView(fractal.AspectRatio);
            fractal.IterationsCount = place.IterationsCount;
            fractal.SetNewView(view);
            fractal.RenderBitmap();
        }
    }
}
