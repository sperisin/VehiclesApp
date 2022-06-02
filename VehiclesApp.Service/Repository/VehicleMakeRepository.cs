using VehiclesApp.Service.Models;
using VehiclesApp.Common.ParametersCommon;
using PagedList;

namespace VehiclesApp.Service.Repository
{

    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IGenericRepository<VehicleMake> Repository;

        public VehicleMakeRepository(IGenericRepository<VehicleMake> repository)
        {
            Repository = repository;
        }
        public async Task AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await Repository.AddAsync(vehicleMake);
        }
        public async Task DeleteVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await Repository.DeleteAsync(vehicleMake);
        }
        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters)
        {
            IEnumerable<VehicleMake>? vehicleMakes;
            vehicleMakes = Repository.GetVehiclesAsync().OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleMakes = Repository.GetVehiclesAsync().Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsEnumerable();
            }
            if (!string.IsNullOrEmpty(sortParameters.Sort))
            {
                if (sortParameters.Sort.ToUpper() == "NAME")
                {
                    vehicleMakes = vehicleMakes.OrderBy(x => x.Name).AsEnumerable();
                }
                else if (sortParameters.Sort.ToUpper() == "ABRV")
                {
                    vehicleMakes = vehicleMakes.OrderBy(x => x.Abrv).AsEnumerable();
                }
            }
            else
            {
                vehicleMakes = vehicleMakes.AsEnumerable();
            }
            if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
            {
                vehicleMakes = vehicleMakes.Reverse();
            }
            if (pagingParameters.PageSize != 0)
            {
                vehicleMakes = vehicleMakes.ToPagedList((int)pagingParameters.Page, pagingParameters.PageSize);
                if (sortParameters.SortDirection != null)
                {
                    if (sortParameters.SortDirection.ToUpper() == "DESCENDING")
                    {
                        vehicleMakes = vehicleMakes.Reverse();
                    }
                }

            }
            else
            {
                return vehicleMakes;
            }

            return vehicleMakes.AsEnumerable();
        }
        public async Task<VehicleMake> GetVehicleMakeAsync(int id)
        {
            return await Repository.GetVehicleAsync(id);
        }
        public async Task UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await Repository.UpdateAsync(vehicleMake);
        }
    }
}