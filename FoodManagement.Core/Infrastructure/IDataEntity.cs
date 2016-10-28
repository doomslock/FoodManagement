using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Core.Infrastructure
{
    public interface IDataEntity
    {
        Guid Id { get; }
    }
}
