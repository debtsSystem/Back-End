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
        public CustomerService Customer { get; set; }

        public DebtsService Debts { get; set; }
        public SaleService Sale { get; set; }

        public DalManager()
        {
            ServiceCollection collection = new ServiceCollection();
            collection.AddSingleton<dbcontext>();
            collection.AddSingleton<PaymentService>();
            collection.AddSingleton<CustomerService>();
            collection.AddSingleton<DebtsService>();
            collection.AddSingleton<SaleService>();


            var serviceprovider = collection.BuildServiceProvider();
            Payment = serviceprovider.GetRequiredService<PaymentService>();
            Customer = serviceprovider.GetRequiredService<CustomerService>();
            Debts = serviceprovider.GetRequiredService<DebtsService>();
            Sale = serviceprovider.GetRequiredService<SaleService>();
        }
    }
}
