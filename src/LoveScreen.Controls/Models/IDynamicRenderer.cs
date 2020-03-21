using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Input;

namespace LoveScreen.Controls.Models
{
    public interface IDynamicRenderer
    {
        Stroke GetStroke(StylusPointCollection StylusPoints, DrawingAttributes DrawingAttributes);
    }
}
