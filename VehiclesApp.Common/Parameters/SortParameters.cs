using VehiclesApp.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.Parameters
{
    public class SortParameters : ISortParameters
    {
        public string Sort { get; set; }
        public string SortDirection { get; set; }
    }
}
