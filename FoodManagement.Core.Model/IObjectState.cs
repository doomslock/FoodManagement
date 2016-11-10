using System.ComponentModel.DataAnnotations.Schema;

namespace FoodManagement.Core.Model
{
    public interface IObjectState
    {
        [NotMapped]
        ObjectState ObjectState { get; set; }
    }
}
