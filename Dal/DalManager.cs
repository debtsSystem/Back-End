using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Dal.DalImplementation;
using Dal.Do;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DalManager
    {
        public PaymentService Payment { get; set; }

        public DalManager()
        {
            ServiceCollection collection = new ServiceCollection();
            collection.AddSingleton<dbcontext>();
            collection.AddSingleton<PaymentService>();
            

            var serviceprovider = collection.BuildServiceProvider();
            Payment = serviceprovider.GetRequiredService<PaymentService>();
        }
    }
}
