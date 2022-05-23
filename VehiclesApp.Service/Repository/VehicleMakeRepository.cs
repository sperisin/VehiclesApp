using VehiclesApp.Service.Models;
using VehiclesApp.Common.ParametersCommon;
using PagedList;

namespace VehiclesApp.Service.Repository
{

    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly AppDbContext appDbContext;

        public VehicleMakeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<VehicleMake> AddVehicleMakeAsync(VehicleMake vehicleMake)
        {
            await appDbContext.VehicleMakes.AddAsync(vehicleMake);
            await appDbContext.SaveChangesAsync();
            return vehicleMake;
        }
        public async Task<VehicleMake> DeleteVehicleMakeAsync(VehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                appDbContext.Remove(vehicleMake);
                await appDbContext.SaveChangesAsync();
            }
            return vehicleMake;
        }
        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPagingParameters pagingParameters)
        {
            IEnumerable<VehicleMake>? vehicleMakes;
            vehicleMakes = appDbContext.VehicleMakes.OrderBy(x => x.Id);
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleMakes = appDbContext.VehicleMakes.Where(x => x.Abrv.ToUpper() == filterParameters.Search.ToUpper() || x.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(x => x.Id).AsEnumerable();
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
        public async Task<VehicleMake> GetVehicleMakeAsync(int Id)
        {
            VehicleMake? vehicleMake = await appDbContext.VehicleMakes.FindAsync(Id);
            return vehicleMake;
        }
        public async Task<VehicleMake> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            var vehicleMakeTemp = appDbContext.VehicleMakes.Attach(vehicleMake);
            vehicleMakeTemp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return vehicleMake;
        }
    }
}