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
    public class SavePlaceToDbViewModel
    {
        public string Name { get; set; }

        public ICommand SavePlaceCommand { get; set; }

        public SavePlaceToDbViewModel()
        {
            SavePlaceCommand = new RelayCommand((arg) => SavePlaceMethod());
            Name = "Название";
        }

        private void SavePlaceMethod()
        {
            Fractal fractal = ((App)Application.Current).Fractal;
            PlaneView view = fractal.View;
            Place place = new Place(view);

            place.Name = Name;
            place.CreationTime = DateTime.Now;
            place.IterationsCount = fractal.IterationsCount;

            using (AppDbContext db = new AppDbContext())
            {
                db.Places.Add(place);
                db.SaveChanges();

                MessageBox.Show("Место успешно добавлено", "Инфо");
            }
        }
    }
}
