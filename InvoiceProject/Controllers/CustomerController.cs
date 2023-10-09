using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IBusinessLogicLayer;
using InvoiceEntities;


namespace InvoiceProject.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        //CustomerService customerService = new CustomerService();
        [HttpPost]
        public JsonResult AjaxMethod(int pageIndex, int PageSize, string sortName, string sortDirection, string search)
        {
            Customer customer = new Customer();
            CustomerPaged model = new CustomerPaged();
            model.PageNumber = pageIndex;
            model.PageSize = PageSize;
            model.sortDirection = sortDirection;
            model.sortBy = sortName;
            model.Search = search;

            model.CustomerList = _customerService.CustomerList(model).ToList();
            if(model.CustomerList != null)
            {
                model.RecordCount = model.CustomerList[0].rowCount;
            }
            else
            {
                model.RecordCount = 0;
            }

            return Json(model);
        }

        public ActionResult ListCustomer()
        {
            return View();
        }
    }
}