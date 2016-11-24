using System;

namespace FoodManagement.Core.Model
{
    public interface IDataEntity : IObjectState
    {
        Guid Id { get; }
    }
}
