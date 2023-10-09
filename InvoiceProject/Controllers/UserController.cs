using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using InvoiceProject.BLL;
//using InvoiceProject.DAL;
//using InvoiceProject.Models;
using IBusinessLogicLayer;
using InvoiceEntities;


namespace InvoiceProject.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin model)
        {

            if (ModelState.IsValid)
            {
                //UserService userService = new UserService();
                if (_userService.AuthenticateUser(model))
                {
                    return RedirectToAction("ListCustomer", "Customer");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid username, or password.");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}