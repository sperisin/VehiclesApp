using VehiclesApp.Service.Models;

namespace VehiclesApp.MVC.Models
{
    public class VehicleMakeVM
    {
        public VehicleMake vehicleMake { get; set; }
        public IEnumerable<VehicleMake> vehicleMakes { get; set; }
    }
}
