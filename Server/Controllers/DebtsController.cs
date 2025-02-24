using BL.BlApi;
using BL.Bo;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtsController : ControllerBase
    {
        BLManager Blmanager;
        IBLDebts Ibldebts;
        public DebtsController(BLManager blManager)
        {
            this.Blmanager = blManager; // אחסן את blManager באובייקט Blmanager
            this.Ibldebts = blManager.BLDebts;
        }

        [Route("GetAllDebts")]
        [HttpGet]
        public List<BLDebts> GetDebtsList()
        {
            return Ibldebts.ReadAll();
        }

        [Route("addDebt/Debt")]
        [HttpPost()]
        public bool Create(BLDebts debts) =>
           Blmanager.BLDebts.Create(debts);

        [Route("DeleteDebts/Code")]
        [HttpDelete()]
        public bool Delete(int Id) =>
            Blmanager.BLDebts.Delete(Id);


        [Route("UpDateDebts/Code")]
        [HttpPut()]
        public bool UpDate(BLDebts debts) =>
            Blmanager.BLDebts.Update(debts);

        [Route("GetDebtsByCode/Code")]
        [HttpGet()]
        public BLDebts GetDebtstByCode(int Id) =>
            Blmanager.BLDebts.Read(Id);
    }
}
