using ColorMine.ColorSpaces;
using fractals_renderer.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace fractals_renderer.Model
{
    public class Fractal
    {
        public int ColorKoef { get; set; }
        public int IterationsCount { get; set; }
        public int ScaleKoef { get; set; }
        public WriteableBitmap Bitmap { get { return bm; } }
        public PlaneView View { get { return view; } }

        private PlaneView view;
        private WriteableBitmap bm;

        public Fractal()
        {
            ColorKoef = 1;
            IterationsCount = 250;
            ScaleKoef = 2;
            view = new PlaneView(-2, 1, 3, 2);
            NewBitmap(900, 600);
        }

        public double AspectRatio { get { return (double)bm.PixelWidth / bm.PixelHeight; } }

        public System.Drawing.Image GetImage()
        {
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(bm.PixelWidth, bm.PixelHeight);
            bm.ForEach((x, y, color) =>
            {
                var c = System.Drawing.Color.FromArgb(color.R, color.G, color.B);
                image.SetPixel(x, y, c);
                return color;
            });
            return image;
        }

        public void ChangeView(double ratioX, double ratioY, double koef)
        {
            view.SetNewCenter(ratioX, ratioY, koef);
        }

        public void SetNewView(PlaneView view)
        {
            this.view = view;
        }

        public void NewBitmap(int width, int height)
        {
            bm = BitmapFactory.New(width, height);
            view.UpdateViewForNewBitmapSize((double)bm.PixelWidth / bm.PixelHeight);
            UpdateViewModelBitmap();
        }

        public void UpdateViewModelBitmap()
        {
            if (Application.Current.MainWindow != null)
                ((MainWindowViewModel)Application.Current.MainWindow.DataContext).ImageSource = bm;
        }

        public void RenderBitmap()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int it = IterationsCount;

            int w = bm.PixelWidth;
            int h = bm.PixelHeight;

            double transformRateX = view.w / w;
            double transformRateY = view.h / h;
            
            short[,] colorSet = new short[w, h];
            
            Parallel.For(0, w, (x) =>
            {
                for (int y = 0; y < h; y++)
                {
                    double a = x * transformRateX + view.x;
                    double b = y * transformRateY - view.y;

                    Complex c = new Complex(a, b);
                    Complex z = new Complex(0, 0);

                    int i = 0;
                    while (i < it)
                    {
                        i++;
                        z.Square();
                        z.Add(c);
                        if (z.SquaredMagnitude() > 4)
                            break;
                    }

                    if (i == it)
                        colorSet[x, y] = 360;
                    else
                        colorSet[x, y] = (short)((i * ColorKoef + Math.Sqrt(a * a + b * b)) % 360);
                }
            });
            bm.ForEach((i, j) => RainbowColors.colors[colorSet[i,j]]);

            sw.Stop();
            ((MainWindowViewModel)Application.Current.MainWindow.DataContext).BottomInfoText = String.Format("Рендер занял {0}с", (double)sw.ElapsedMilliseconds / 1000);
        }
    }
}
