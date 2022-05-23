using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.ParametersCommon
{
    public interface IFilterParameters
    {
        string Search { get; set; }
        int? VehicleMakeId { get; set; }
    }
}
