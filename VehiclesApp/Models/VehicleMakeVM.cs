using X.PagedList;
using VehiclesApp.Service.Models;

namespace VehiclesApp.MVC.Models
{
    public class VehicleMakeVM
    {
        public VehicleMake vehicleMake { get; set; }
        public IPagedList<VehicleMake> vehicleMakes { get; set; }
        public string search { get; set; }
        public string sort { get; set; }
        public string sortDirection { get; set; }
        public int? page { get; set; }
        public int? pageSize { get; set; }
    }
}
