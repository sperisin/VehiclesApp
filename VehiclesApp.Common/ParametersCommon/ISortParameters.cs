using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.ParametersCommon
{
    public interface ISortParameters
    {
        string Sort { get; set; }
        string SortDirection { get; set; }
    }
}
