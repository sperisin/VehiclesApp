using VehiclesApp.Service.Models;

namespace VehiclesApp.MVC.Models
{
    public class VehicleModelVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int vehicleMakeId { get; set; }
        public VehicleModel vehicleModel { get; set; }
        public IEnumerable<VehicleMake> vehicleMakes { get; set; }
        public IEnumerable<VehicleModel> vehicleModels { get; set; }    
    }
}
