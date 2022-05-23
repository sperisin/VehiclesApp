using VehiclesApp.Common.ParametersCommon;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service.Repository
{

    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters);
        Task<VehicleMake> GetVehicleMakeAsync(int Id);
        Task<VehicleMake> AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        Task<VehicleMake> DeleteVehicleMakeAsync(VehicleMake vehicleMake);
    }
}