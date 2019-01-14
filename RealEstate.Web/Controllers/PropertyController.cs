using Newtonsoft.Json;
using RealEstate.Data.Repository.IRepository;
using RealEstate.Infrastructure.AzureHelpers;
using RealEstate.Model.QueueMessage;
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
    public class PropertyController : BaseController
    {
        private readonly IRealEstatePropertyRepository realEstatePropertyRepository;
        private readonly IRealEstatePropertyInterestRepository realEstatePropertyInterestRepository;

        public PropertyController(IRealEstatePropertyRepository realEstatePropertyRepository, IRealEstatePropertyInterestRepository realEstatePropertyInterestRepository)
        {
            this.realEstatePropertyRepository = realEstatePropertyRepository;
            this.realEstatePropertyInterestRepository = realEstatePropertyInterestRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            var model = realEstatePropertyRepository.GetRealEstateProperties().Map();
            return View(model);
        }

        public ActionResult SearchProperty(string searchBy, string searchString)
        {
            var model = realEstatePropertyRepository.GetRealEstateProperties(searchBy, searchString).Map();
            return View("Index",model);
        }

        public ActionResult PropertyDetails(long propertyId)
        {
            var propertyInterest = realEstatePropertyInterestRepository.GetRealEstatePropertyInterests(propertyId, UserId);
            var model = realEstatePropertyRepository.GetRealEstateProperty(propertyId).Map();
            model.IsInterested = propertyInterest.Any();
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
                    //Add to Azure Storage Queue for Notifaction
                    AddToAzureStorageQueue(propertyViewModel.PropertyId, UserId, UserName);
                }
                return RedirectToAction("PropertyDetails", new { propertyId = propertyViewModel.PropertyId });
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
            catch 
            {
                throw;
            }
        }

        private void AddToAzureStorageQueue(long propertyId, string userId,string userName)
        {
            var message = new PropertyChangeNotificationMessage(propertyId, userId, userName);
            var messageString = JsonConvert.SerializeObject(message);
            AzureQueueHelper.AddAzureQueueMessage(messageString);
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
                    propertyViewModel.OwnedBy = UserId;
                    var realEstateProperty = propertyViewModel.Map();
                    var result = await realEstatePropertyRepository.CreateRealEstateProperty(realEstateProperty);
                    propertyViewModel = result.Map();
                }
                return RedirectToAction("Index");
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
            catch 
            {
                throw;
            }
        }
    }
}