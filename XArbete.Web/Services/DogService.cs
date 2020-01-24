using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Data;
using XArbete.Web.Customer.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Web.Services
{
    public class DogService : ServiceBase<Dog>, IDogService
    {
        public DogService(XArbeteContext context) : base(context)
        {
        }
        public async Task<int> DeleteCustomerDogs(int id)
        {
            var connectedDogs = GetMany(a => a.CustomerID == id);
            int dogsCount = 0;
            foreach (var dog in connectedDogs)
            {
                Delete(dog);
                dogsCount++;
            }
            return dogsCount;
        }
    }
}
