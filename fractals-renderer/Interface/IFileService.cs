using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Interface
{
    public interface IFileService
    {
        void Save(string filename, Image image);
    }
}
