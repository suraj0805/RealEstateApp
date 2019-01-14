using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstate.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public string UserId { get { return User.Identity.GetUserId(); } }

        public string UserName { get { return User.Identity.GetUserName(); } }
    }
}