using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Model
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double W { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public int IterationsCount { get; set; }

        public Place() { }

        public Place(PlaneView view)
        {
            CenterX = view.x + view.w / 2;
            CenterY = view.y - view.h / 2;
            W = view.w;
        }

        public PlaneView ToView(double aspectRatio)
        {
            double h = W / aspectRatio;
            return new PlaneView(CenterX - W / 2, CenterY + h / 2, W, h);
        }
    }
}
