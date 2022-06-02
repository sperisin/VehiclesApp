using Ninject.Modules;
using VehiclesApp.Common.Parameters;
using VehiclesApp.Common.ParametersCommon;

namespace VehiclesApp.Common
{
    public class DImodule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFilterParameters>().To<FilterParameters>();
            Bind<ISortParameters>().To<SortParameters>();
            Bind<IPagingParameters>().To<PagingParameters>();
        }
    }
}
