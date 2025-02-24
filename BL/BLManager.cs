using BL.BlApi;
using BL.BlImplementation;
using BL.Bo;
using Dal;
using Microsoft.Extensions.DependencyInjection;

namespace BL
{
    public class BLManager
    {
        public IBLPayment BLPayment{ get; }
        public IBlCustomer BLCustomer { get; }

        public IBLDebts BLDebts { get; }

        public IBLSale BLSale { get; }


        public BLManager()
        {
            ServiceCollection collection = new ServiceCollection();
            collection.AddSingleton<DalManager>();
            collection.AddSingleton<IBlCustomer, BLCustomerService>();
            collection.AddSingleton<IBLPayment, BLPaymentService>();
            collection.AddSingleton<IBLDebts, BLDebtsService>();
            collection.AddSingleton<IBLSale, BLSaleService>();


            var ServiceProvider = collection.BuildServiceProvider();
            BLPayment = ServiceProvider.GetRequiredService<IBLPayment>();
            BLCustomer = ServiceProvider.GetRequiredService<IBlCustomer>();
            BLDebts = ServiceProvider.GetRequiredService<IBLDebts>();
            BLSale = ServiceProvider.GetRequiredService<IBLSale>();


        }
    }
}
