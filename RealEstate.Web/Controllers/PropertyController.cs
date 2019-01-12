using RealEstate.Data.Repository.IRepository;
using RealEstate.Web.Mappers;
using RealEstate.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Web.Controllers
{
    [Authorize]
    public class PropertyController : Controller
    {
        private readonly IRealEstatePropertyRepository realEstatePropertyRepository;

        public PropertyController(IRealEstatePropertyRepository realEstatePropertyRepository)
        {
            this.realEstatePropertyRepository = realEstatePropertyRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            var model = realEstatePropertyRepository.GetRealEstateProperties().Map();
            return View(model);
        }

        public ActionResult SearchProperty(string searchBy, string searchString)
        {
            ViewData["SearchBy"] = searchBy;
            ViewData["SearchString"] = searchString;
            var model = realEstatePropertyRepository.GetRealEstateProperties(searchBy, searchString).Map();
            return View("Index",model);
        }

        public ActionResult PropertyDetails(long propertyId)
        {
            var model = realEstatePropertyRepository.GetRealEstateProperty(propertyId).Map();
            return View(model);
        }

        [HttpGet]
        public ActionResult EditProperty(long propertyId)
        {
            var propertyViewModel = realEstatePropertyRepository.GetRealEstateProperty(propertyId).Map();
            return View(propertyViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditProperty(PropertyViewModel propertyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var realEstateProperty = propertyViewModel.Map();
                    var result = await realEstatePropertyRepository.EditRealEsateProperty(realEstateProperty);
                    propertyViewModel = result.Map();
                }
                return View(propertyViewModel);
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("NullArguments",ex);
                return View(propertyViewModel);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("InvalidOperation", ex);
                return View(propertyViewModel);
            }
            catch (Exception ex)
            {
                return View(propertyViewModel);
            }
        }

        [HttpGet]
        public ActionResult CreateProperty() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProperty(PropertyViewModel propertyViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var realEstateProperty = propertyViewModel.Map();
                    var result = await realEstatePropertyRepository.CreateRealEstateProperty(realEstateProperty);
                    propertyViewModel = result.Map();
                }
                return View(propertyViewModel);
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("NullArguments", ex);
                return View(propertyViewModel);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("InvalidOperation", ex);
                return View(propertyViewModel);
            }
            catch (Exception ex)
            {
                return View(propertyViewModel);
            }
        }
    }
}