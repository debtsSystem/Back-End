using BL.BlApi;
using BL.Bo;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        BLManager Blmanager;
        IBLSale Iblsale;
        public SalesController(BLManager blManager)
        {
            this.Blmanager = blManager; // אחסן את blManager באובייקט Blmanager
            this.Iblsale = blManager.BLSale;
        }

        [Route("GetAllSale")]
        [HttpGet]
        public List<BLSale> GetSaleList()
        {
            return Iblsale.ReadAll();
        }

        [Route("addSale/Sale")]
        [HttpPost()]
        public bool Create(BLSale sale) =>
           Blmanager.BLSale.Create(sale);

        [Route("DeleteSale/Code")]
        [HttpDelete()]
        public bool Delete(int Id) =>
            Blmanager.BLSale.Delete(Id);


        [Route("UpDateSale/Code")]
        [HttpPut()]
        public bool UpDate(BLSale sale) =>
            Blmanager.BLSale.Update(sale);

        [Route("GetSaleByCode/Code")]
        [HttpGet()]
        public BLSale GetSaleByCode(int Id) =>
            Blmanager.BLSale.Read(Id);
    }
}
