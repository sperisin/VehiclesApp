using Microsoft.EntityFrameworkCore;
using VehiclesApp.Service.Models;
using PagedList;

namespace VehiclesApp.Service
{
    public class VehicleServiceRepository : IVehicleServiceRepository
    {
        private readonly AppDbContext appDbContext;

        public VehicleServiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<VehicleMake> CreateMake(VehicleMake Make)
        {
            await appDbContext.VehicleMakes.AddAsync(Make);
            await appDbContext.SaveChangesAsync();
            return Make;
        }

        public async Task<VehicleModel> CreateModel(VehicleModel Model)
        {
            await appDbContext.VehicleModels.AddAsync(Model);
            await appDbContext.SaveChangesAsync();
            return Model;
        }

        public async Task<VehicleMake> DeleteMake(int Id)
        {
            VehicleMake? make = appDbContext.VehicleMakes.Find(Id);
            if (make != null)
            {
                appDbContext.VehicleMakes.Remove(make);
                await appDbContext.SaveChangesAsync();
            }
            return make;
        }

        public async Task<VehicleModel> DeleteModel(int Id)
        {
            VehicleModel? model = appDbContext.VehicleModels.Find(Id);
            if (model != null)
            {
                appDbContext.VehicleModels.Remove(model);
                await appDbContext.SaveChangesAsync();
            }
            return model;
        }

        public async Task<IEnumerable<VehicleMake>> GetAllMakes(string sortOrder = "", string filter = "")
        {
            if ((filter == "") || filter == null)
            {
                if (sortOrder == "name_desc")
                {
                    return appDbContext.VehicleMakes.OrderByDescending(x => x.Name);
                }
                return appDbContext.VehicleMakes.OrderBy(x => x.Name);
            }
            else
            {
                if (sortOrder == "name_desc")
                {
                    return appDbContext.VehicleMakes.Where(x => x.Name.Contains(filter)).OrderByDescending(x => x.Name);
                }
                return appDbContext.VehicleMakes.Where(x => x.Name.Contains(filter)).OrderBy(x => x.Name);
            }
        }
        public async Task<IEnumerable<VehicleModel>> GetModels(string sortOrder = "", string filter = "", VehicleMake? vehicleMake = null, int page = 1, int pageSize = 20)
        {
            if (page == 0)
                page = 1;
            if (pageSize == 0)
                pageSize = 20;
            if (sortOrder == "name_desc" && filter == "" && vehicleMake == null)
                return appDbContext.VehicleModels.OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
            else if (sortOrder == "name_desc" && filter != "" && vehicleMake == null)
                return appDbContext.VehicleModels.Where(x => x.Name.Contains(filter)).OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
            else if (sortOrder == "name_desc" && filter != "" && vehicleMake != null)
                return appDbContext.VehicleModels.Where(x => x.Name.Contains(filter)).Where(x => x.vehicleMake == vehicleMake).OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
            else if (sortOrder == "name_desc" && filter == "" && vehicleMake != null)
                return appDbContext.VehicleModels.Where(x => x.vehicleMake == vehicleMake).OrderByDescending(x => x.Name).ToPagedList(page, pageSize);
             
            if (sortOrder == "name_asc" && filter != "" && vehicleMake == null)
                return appDbContext.VehicleModels.Where(x => x.Name.Contains(filter)).OrderBy(x => x.Name).ToPagedList(page, pageSize);
            else if (sortOrder == "name_asc" && filter != "" && vehicleMake != null)
                return appDbContext.VehicleModels.Where(x => x.Name.Contains(filter)).Where(x => x.vehicleMake == vehicleMake).OrderBy(x => x.Name).ToPagedList(page, pageSize);
            else if (sortOrder == "name_asc" && filter == "" && vehicleMake != null)
                return appDbContext.VehicleModels.Where(x => x.vehicleMake == vehicleMake).OrderBy(x => x.Name).ToPagedList(page, pageSize);
            
            return sortOrder == "" ? appDbContext.VehicleModels.ToPagedList(page, pageSize) : appDbContext.VehicleModels.Where(x => x.Name.Contains(filter)).ToPagedList(page, pageSize);
        }

        public async Task<VehicleMake> GetMake(int Id)
        {
            VehicleMake? make = await appDbContext.VehicleMakes.FindAsync(Id);
            return make;
        }

        public async Task<VehicleModel> GetModel(int Id)
        {
            VehicleModel? model = await appDbContext.VehicleModels.FindAsync(Id);
            return model;
        }

        public async Task<VehicleMake> UpdateMake(VehicleMake Make)
        {
            var vehicleMake = appDbContext.VehicleMakes.Attach(Make);
            vehicleMake.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return Make;
        }

        public async Task<VehicleModel> UpdateModel(VehicleModel Model)
        {
            var vehicleModel = appDbContext.VehicleModels.Attach(Model);
            vehicleModel.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return Model;
        }
    }
}