using fractals_renderer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Service
{
    class FileService : IFileService
    {
        public void Save(string filePath, Image image)
        {
            image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
