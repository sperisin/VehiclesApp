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
        IEnumerable<VehicleMake> GetAllMakes(string sortOrder = "", string filter = "");
        Task<VehicleMake> GetMake(int Id);
        Task<VehicleMake> CreateMake(VehicleMake Make);
        Task<VehicleMake> UpdateMake(VehicleMake Make);
        Task<VehicleMake> DeleteMake(int Id);
        // Models
        IEnumerable<VehicleModel> GetModels(string sortOrder = "", string filter = "", VehicleMake? vehicleMake = null);
        Task<VehicleModel> GetModel(int Id);
        Task<VehicleModel> CreateModel(VehicleModel Model);
        Task<VehicleModel> UpdateModel(VehicleModel Model);
        Task<VehicleModel> DeleteModel(int Id);

    }
}
