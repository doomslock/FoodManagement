using FoodManagement.Core;
using FoodManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Infrastructure.Dal
{
    public class StoreRepository : GenericRepository<Store>, IRepository<Store>
    {
        public StoreRepository(IDataContext context) : base(context)
        {
        }
    }
}
