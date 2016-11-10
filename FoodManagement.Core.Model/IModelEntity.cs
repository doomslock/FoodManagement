using System;

namespace FoodManagement.Core.Model
{
    public interface IModelEntity : IObjectState
    {
        Guid Id { get;}
    }
}
