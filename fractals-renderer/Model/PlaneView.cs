using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Model
{
    public class PlaneView
    {
        public double x;
        public double y;
        public double w;
        public double h;

        public PlaneView(double x, double y, double w, double h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public void SetNewCenter(double ratioX, double ratioY, double koef)
        {
            double newCenterX = x + ratioX * w;
            double newCenterY = y - ratioY * h;
            w *= koef;
            h *= koef;
            x = newCenterX - w / 2;
            y = newCenterY + h / 2;
        }

        public void UpdateViewForNewBitmapSize(double aspectRatio)
        {
            double centerY = y - h / 2;
            h = w / aspectRatio;
            y = centerY + h / 2;
        }
    }
}