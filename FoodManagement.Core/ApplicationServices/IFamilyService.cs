using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Core
{
    public interface IFamilyService
    {
        bool PersonIsAuthorizedToFamily(Guid personId, Guid familyId);
    }
}
