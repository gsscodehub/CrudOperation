using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperation.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerDAL customerDAL = null;
        public CustomerController(IConfiguration configuration)
        {
            customerDAL = new CustomerDAL(configuration);
        }
        public IActionResult Index()
        {
            IEnumerable<Customer> cust = customerDAL.GetCustomerList();
            return View(cust);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
           bool b = customerDAL.CreateCustomer(customer);
            if(b == true)
            {
                return RedirectToAction("Index");
            }
          return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            Customer c = customerDAL.EditCustomer(Id);
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            bool b = customerDAL.UpdateCustomer(customer);
            if (b == true)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
