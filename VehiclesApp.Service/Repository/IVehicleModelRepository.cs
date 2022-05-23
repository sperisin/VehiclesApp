using VehiclesApp.Common.ParametersCommon;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service.Repository
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters, VehicleMake vehicleMake);
        Task<VehicleModel> GetVehicleModelAsync(int Id);
        Task<VehicleModel> AddVehicleModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> DeleteVehicleModelAsync(VehicleModel vehicleModel);
    }
}
