using BL;
using BL.BlApi;
using BL.Bo;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        BLManager Blmanager;
        IBLPayment Iblpayment;
        public PaymentController(BLManager blManager)
        {
            this.Blmanager = blManager; // אחסן את blManager באובייקט Blmanager
            this.Iblpayment = blManager.BLPayment;
        }

        [Route("GetAllPayment")]
        [HttpGet]
        public List<BLPayment> GetPaymentList()
        {
           return Iblpayment.ReadAll();
        }

        [Route("addTypeOfPayment/TypeOfPayment")]
        [HttpPost()]
        public bool Create(BLPayment payment) =>
           Blmanager.BLPayment.Create(payment);
    }
}
