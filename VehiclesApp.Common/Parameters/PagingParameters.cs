using VehiclesApp.Common.ParametersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.Parameters
{
    public class PagingParameters : IPagingParameters
    {
        public int? Page { get; set; }
        public int PageSize { get; set; }
    }
}
