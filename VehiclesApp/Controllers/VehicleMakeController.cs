using Microsoft.AspNetCore.Mvc;
using VehiclesApp.Service;
using VehiclesApp.Common.Parameters;
using VehiclesApp.MVC.Models;
using X.PagedList;
using AutoMapper;
using VehiclesApp.Service.Models;
using VehiclesApp.Service.Repository;

namespace VehiclesApp.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IMapper _mapper;
        IVehicleMakeRepository _vehicleMakeRepository;
        public VehicleMakeController(IMapper mapper, IVehicleMakeRepository vehicleMakeRepository)
        {
            this._mapper = mapper;
            this._vehicleMakeRepository = vehicleMakeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<RedirectToActionResult> Create(VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleMakeRepository.AddVehicleMakeAsync(vehicleMake);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            VehicleMake vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(id);
            VehicleMakeVM vehicleMakeVM = new VehicleMakeVM()
            {
                vehicleMake = vehicleMake
            };
            return View(vehicleMakeVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                await _vehicleMakeRepository.UpdateVehicleMakeAsync(vehicleMake);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Index([FromQuery] int? page, int? pagesize, string search, string sort, string direction)
        {
            var sortParameters = new SortParameters()
            {
                Sort = sort,
                SortDirection = direction ?? "Descending"
            };
            var filterParameters = new FilterParameters()
            {
                Search = search
            };
            var pagingParameters = new PagingParameters()
            {
                Page = page ?? 1,
                PageSize = pagesize ?? 5
            };
            var vehicleMakeList = await _vehicleMakeRepository.GetVehicleMakesAsync(sortParameters, filterParameters, pagingParameters);
            VehicleMakeVM vehicleMakeVM = new VehicleMakeVM()
            {
                vehicleMakes = vehicleMakeList.ToPagedList((int)pagingParameters.Page, pagingParameters.PageSize),
                search = search,
                sort = sort,
                sortDirection = direction,
                page = page,
                pageSize = pagesize

            };
            return View(vehicleMakeVM);
        }
        public async Task<JsonResult> GetVehicleMakeById([FromQuery] int vehicleId)
        {
            VehicleMake vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(vehicleId);
            return Json(vehicleMake);
        }
        public async Task<JsonResult> DeleteVehicleMake([FromQuery] int vehicleId)
        {
            VehicleMake vehicleMake = await _vehicleMakeRepository.GetVehicleMakeAsync(vehicleId);
            if (vehicleMake != null)
            {
                await _vehicleMakeRepository.DeleteVehicleMakeAsync(vehicleMake);
            }
            return Json(vehicleMake);
        }
    }
}
