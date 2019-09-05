using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YznVsPlug.BLL
{
    public interface IAbpCtlItem
    {
        string GetText();

        List<string> Dtos { get; }

        IAbpAppItem ToAppItem();
    }
}