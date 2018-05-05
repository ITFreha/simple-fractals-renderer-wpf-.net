using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Model
{
    class Complex
    {
        public double a;    //real
        public double b;    //imaginary

        public Complex(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void Square()
        {
            double t = (a * a) - (b * b);
            b = 2 * a * b;
            a = t;
        }

        public double SquaredMagnitude()
        {
            return a * a + b * b;
        }

        public void Add(Complex c)
        {
            a += c.a;
            b += c.b;
        }
    }
}
