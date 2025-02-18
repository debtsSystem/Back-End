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

        public BLManager()
        {
            ServiceCollection collection = new ServiceCollection();
            collection.AddSingleton<DalManager>();
            collection.AddSingleton<IBLPayment, BLPaymentService>();

            var ServiceProvider = collection.BuildServiceProvider();
            BLPayment = ServiceProvider.GetRequiredService<IBLPayment>();
        }
    }
}
