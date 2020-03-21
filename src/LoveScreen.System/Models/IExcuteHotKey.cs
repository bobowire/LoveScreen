using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.Models
{
    public interface IExcuteHotKey
    {
        void ExcuteHotKeyCommand(int id);
        bool IsEffective();
    }
}
