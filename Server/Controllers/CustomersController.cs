using BL.BlApi;
using BL.Bo;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

            BLManager Blmanager;
            IBlCustomer Iblcustomer;
            public CustomersController(BLManager blManager)
            {
                this.Blmanager = blManager; // אחסן את blManager באובייקט Blmanager
                this.Iblcustomer = blManager.BLCustomer;
            }

            [Route("GetAllCustomer")]
            [HttpGet]
            public List<BLCustomer> GetCustomerList()
            {
                return Iblcustomer.ReadAll();
            }

            [Route("addCustomer/Customer")]
            [HttpPost()]
            public bool Create(BLCustomer customer) =>
               Blmanager.BLCustomer.Create(customer);

            [Route("DeleteCustomer/Code")]
            [HttpDelete()]
            public bool Delete(int Id) =>
                Blmanager.BLCustomer.Delete(Id);


            [Route("UpDateCustomer/Code")]
            [HttpPut()]
            public bool UpDate(BLCustomer customer) =>
                Blmanager.BLCustomer.Update(customer);

            [Route("GetCustomerCode/Code")]
            [HttpGet()]
            public BLCustomer GetCustomerByCode(int Id) =>
                Blmanager.BLCustomer.Read(Id);
        }
    
}
