using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesApp.Service.Models;

namespace VehiclesApp.Service
{
    public interface IVehicleServiceRepository
    {
        // Makes
        Task<IEnumerable<VehicleMake>> GetAllMakes(string sortOrder = "", string filter = "");
        Task<VehicleMake> GetMake(int Id);
        Task<VehicleMake> CreateMake(VehicleMake Make);
        Task<VehicleMake> UpdateMake(VehicleMake Make);
        Task<VehicleMake> DeleteMake(int Id);
        // Models
        Task<IEnumerable<VehicleModel>> GetModels(string sortOrder = "", string filter = "", VehicleMake? vehicleMake = null, int page = 1, int pageSize = 20);
        Task<VehicleModel> GetModel(int Id);
        Task<VehicleModel> CreateModel(VehicleModel Model);
        Task<VehicleModel> UpdateModel(VehicleModel Model);
        Task<VehicleModel> DeleteModel(int Id);

    }
}
