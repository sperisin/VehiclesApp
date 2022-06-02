using VehiclesApp.Service;
using VehiclesApp.Service.Models;
using VehiclesApp.Common.ParametersCommon;
using PagedList;

namespace VehiclesApp.Service.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IGenericRepository<VehicleModel> Repository;

        public VehicleModelRepository(IGenericRepository<VehicleModel> repository)
        {
            Repository = repository;
        }
        public async Task AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            await Repository.AddAsync(vehicleModel);
        }

        public async Task DeleteVehicleModelAsync(VehicleModel vehicleModel)
        {
            await Repository.DeleteAsync(vehicleModel);
        }

        public async Task<VehicleModel> GetVehicleModelAsync(int id)
        {
            return await Repository.GetVehicleAsync(id);
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters, int? vehicleMakeId)
        {
            IEnumerable<VehicleModel>? vehicleModels;
            if (vehicleMakeId != null)
            {
                vehicleModels = Repository.GetVehiclesAsync().Where(x => x.vehicleMakeId == vehicleMakeId);
            }
            else
            {
                vehicleModels = Repository.GetVehiclesAsync().OrderBy(x => x.Id);
            }
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleModels = vehicleModels.Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsEnumerable();
            }
            if (filterParameters.VehicleMakeId != null)
            {
                vehicleModels = vehicleModels.Where(x => x.vehicleMakeId == filterParameters.VehicleMakeId);
            }
            if (!string.IsNullOrEmpty(sortParameters.Sort))
            {
                if (sortParameters.Sort.ToUpper() == "NAME")
                {
                    vehicleModels = vehicleModels.OrderBy(x => x.Name).AsEnumerable();
                }
                else if (sortParameters.Sort.ToUpper() == "ABRV")
                {
                    vehicleModels = vehicleModels.OrderBy(x => x.Abrv).AsEnumerable();
                }
            }
            else
            {
                vehicleModels = vehicleModels.OrderBy(x => x.Id).AsEnumerable();
            }
            if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
            {
                vehicleModels.Reverse();
            }
            if (pagingParameters.PageSize != 0)
            {
                vehicleModels = vehicleModels.ToPagedList((int)pagingParameters.Page, pagingParameters.PageSize);
                if (sortParameters.SortDirection != null)
                {
                    if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                    {
                        vehicleModels = vehicleModels.Reverse();
                    }
                }
            }
            else
            {
                return vehicleModels;
            }
            return vehicleModels.AsEnumerable();
        }

        public async Task UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            await Repository.UpdateAsync(vehicleModel);
        }
    }
}
