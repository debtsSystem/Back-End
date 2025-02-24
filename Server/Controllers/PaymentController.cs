using BL;
using BL.BlApi;
using BL.Bo;
using Dal;
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

        [Route("DeletePaymentType/Code")]
        [HttpDelete()]
        public bool Delete(int Id) =>
            Blmanager.BLPayment.Delete(Id);


        [Route("UpDatePaymentType/Code")]
        [HttpPut()]
        public bool UpDate(BLPayment payment) =>
            Blmanager.BLPayment.Update(payment);

        [Route("GetPaymentByCode/Code")]
        [HttpGet()]
        public BLPayment GetPaymentByCode(int Id) =>
            Blmanager.BLPayment.Read(Id);
    }
}
