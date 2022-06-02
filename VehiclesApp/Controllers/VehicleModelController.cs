using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehiclesApp.MVC.Models;
using VehiclesApp.Service;
using VehiclesApp.Service.Repository;
using VehiclesApp.Common.Parameters;
using AutoMapper;
using VehiclesApp.Service.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VehiclesApp.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        IVehicleMakeRepository _vehicleMakeRepository;
        IVehicleModelRepository _vehicleModelRepository;
        private readonly IMapper _mapper;
        public VehicleModelController(IMapper mapper, IVehicleModelRepository _vehicleModelRepository, IVehicleMakeRepository _vehicleMakeRepository)
        {
            this._mapper = mapper;
            this._vehicleModelRepository = _vehicleModelRepository;
            this._vehicleMakeRepository = _vehicleMakeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var sortParameters = new SortParameters()
            {
                Sort = "Name",
                SortDirection = "Ascending"
            };
            var filterParameters = new FilterParameters();
            var pagingParameters = new PagingParameters();
            var vehiclesMakesList = await _vehicleMakeRepository.GetVehicleMakesAsync(sortParameters, filterParameters, pagingParameters);
            VehicleModelVM vehicleModelVM = new VehicleModelVM()
            {
                vehicleMakes = vehiclesMakesList
            };

            return View(vehicleModelVM);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> Create(VehicleModelVM vModelVM)
        {
            VehicleMake vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(vModelVM.vehicleMakeId);
            VehicleModel vehicleModel = new VehicleModel()
            { 
                Id = vModelVM.Id,
                Name = vModelVM.Name,
                Abrv = vModelVM.Abrv,
                vehicleMake = vehicleMake,
                vehicleMakeId = vModelVM.vehicleMakeId
             };
             await _vehicleModelRepository.AddVehicleModelAsync(vehicleModel);
            
             return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            VehicleModel vehicleModel = await _vehicleModelRepository.GetVehicleModelAsync(id);
            VehicleModelVM vehicleModelVM = new VehicleModelVM()
            {
                vehicleModel = vehicleModel
            };
            return View(vehicleModelVM);
        }
        public async Task<IActionResult> Index([FromQuery] int? page, int? pagesize, string search, string sort, string direction, int makeId)
        {
            var sortParameters = new SortParameters()
            {
                Sort = sort,
                SortDirection = direction ?? "Ascending"
            };
            var pagingParameters = new PagingParameters()
            {
                Page = page ?? 1,
                PageSize = pagesize ?? 0
            };
            var filterParameters = new FilterParameters()
            {
                Search = search
            };
            VehicleMake vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(makeId);
            var vehicleModelList = await _vehicleModelRepository.GetVehicleModelsAsync(sortParameters, filterParameters, pagingParameters, makeId);
            var vehicleMakesList = await _vehicleMakeRepository.GetVehicleMakesAsync(sortParameters, filterParameters, pagingParameters);
            VehicleModelVM vehicleModelVM = new VehicleModelVM()
            {
                vehicleModels = vehicleModelList
            };

            return View(vehicleModelVM);
        }
    }
}