using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public interface IDataArgument
    {
        string GetName();
        object GetValue();
        object GetArgument();
    }
}
