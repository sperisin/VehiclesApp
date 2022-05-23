using VehiclesApp.Service;
using VehiclesApp.Service.Models;
using VehiclesApp.Common.ParametersCommon;
using PagedList;

namespace VehiclesApp.Service.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly AppDbContext appDbContext;

        public VehicleModelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<VehicleModel> AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            await appDbContext.VehicleModels.AddAsync(vehicleModel);
            await appDbContext.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<VehicleModel> DeleteVehicleModelAsync(VehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                appDbContext.Remove(vehicleModel);
                await appDbContext.SaveChangesAsync();
            }
            return vehicleModel;
        }

        public async Task<VehicleModel> GetVehicleModelAsync(int Id)
        {
            VehicleModel? vehicleModel = await appDbContext.VehicleModels.FindAsync(Id);
            return vehicleModel;
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters, VehicleMake vehicleMake)
        {
            IEnumerable<VehicleModel>? vehicleModels;
            if (vehicleMake != null)
            {
                vehicleModels = appDbContext.VehicleModels.Where(x => x.Id == vehicleMake.Id);
            }
            vehicleModels = appDbContext.VehicleModels.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleModels = appDbContext.VehicleModels.Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsEnumerable();
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

        public async Task<VehicleModel> UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            var vehicleModelTemp = appDbContext.VehicleModels.Attach(vehicleModel);
            vehicleModelTemp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return vehicleModel;
        }
    }
}
