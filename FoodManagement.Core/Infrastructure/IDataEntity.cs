using FoodManagement.Core.Model;
using System;

namespace FoodManagement.Core
{
    public interface IDataEntity : IObjectState
    {
        Guid Id { get; }
    }
}
