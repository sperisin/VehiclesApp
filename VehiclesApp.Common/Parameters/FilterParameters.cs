using VehiclesApp.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.Parameters
{
    public class FilterParameters : IFilterParameters
    {
        public string Search { get; set; }
        public int? VehicleMakeId { get; set; }
    }
}
