using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fractals_renderer.Interface
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool SaveFileDialog();
    }
}
