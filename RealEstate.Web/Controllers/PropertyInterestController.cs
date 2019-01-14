using RealEstate.Data.Repository.IRepository;
using RealEstate.Model;
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
    public class PropertyInterestController : BaseController
    {
        private readonly IRealEstatePropertyInterestRepository realEstatePropertyInterestRepository;

        public PropertyInterestController(IRealEstatePropertyInterestRepository realEstatePropertyInterestRepository)
        {
            this.realEstatePropertyInterestRepository = realEstatePropertyInterestRepository;
        }

        // GET: PropertyInterest
        public ActionResult Index()
        {
            var model = realEstatePropertyInterestRepository.GetRealEstatePropertyInterests(UserId).Map();
            return View(model);
        }

        public async Task<ActionResult> RemovePropertyInterest(long propertyId)
        {
            try
            {
                await realEstatePropertyInterestRepository.DeleteRealEstatePropertyInterest(propertyId,UserId);
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch (ArgumentNullException ex) 
            {
                //Log ex
                ViewBag.Error = "Unabled to remove the property interest";
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch (ArgumentException ex)
            {
                //Log ex
                ViewBag.Error = "Unabled to remove the property interest";
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch
            {
                throw;
            }
        }

        public async Task<ActionResult> AddPropertyInterest(long propertyId)
        {
            try
            {
                var propertyInterest = new RealEstatePropertyInterest()
                {
                    PropertyId = propertyId,
                    UserId = UserId
                };
                await realEstatePropertyInterestRepository.CreateRealEstatePropertyInterest(propertyInterest);
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch (ArgumentNullException ex)
            {
                ViewBag.Error = "Invalid Property";
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = "Invalid Property";
                return RedirectToAction("PropertyDetails", "Property", new { propertyId });
            }
            catch { throw; }
        }
    }
}