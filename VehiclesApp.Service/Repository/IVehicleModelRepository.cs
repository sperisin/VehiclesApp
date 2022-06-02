using VehiclesApp.Common.ParametersCommon;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service.Repository
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters, int? vehicleMake);
        Task<VehicleModel> GetVehicleModelAsync(int Id);
        Task AddVehicleModelAsync(VehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(VehicleModel vehicleModel);
        Task DeleteVehicleModelAsync(VehicleModel vehicleModel);
    }
}
