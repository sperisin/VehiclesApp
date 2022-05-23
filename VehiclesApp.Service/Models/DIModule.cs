using Ninject.Modules;
using VehiclesApp.Service.Repository;

namespace VehiclesApp.Service.Models;

class DIModule : NinjectModule
{
    public override void Load()
    {
        Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();
        Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
    }
}
