using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesApp.Service.Models
{
    class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleServiceRepository>().To<VehicleServiceRepository>();
        }
    }
}
