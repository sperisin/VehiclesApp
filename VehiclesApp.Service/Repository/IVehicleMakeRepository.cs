using VehiclesApp.Common.ParametersCommon;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service.Repository
{

    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters);
        Task<VehicleMake> GetVehicleMakeAsync(int Id);
        Task AddVehicleMakeAsync(VehicleMake vehicleMake);
        Task UpdateVehicleMakeAsync(VehicleMake vehicleMake);
        Task DeleteVehicleMakeAsync(VehicleMake vehicleMake);
    }
}