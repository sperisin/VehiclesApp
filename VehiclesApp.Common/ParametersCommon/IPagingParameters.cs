using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Common.ParametersCommon
{
    public interface IPagingParameters
    {
        int? Page { get; set; }
        int PageSize { get; set; }
    }
}
