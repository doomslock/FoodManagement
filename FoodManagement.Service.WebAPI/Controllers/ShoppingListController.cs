using FoodManagement.Core;
using FoodManagement.Core.DTO;
using System;
using System.Linq;
using System.Web.Configuration;
using System.Web.Http;

namespace FoodManagement.Service.WebAPI.Controllers
{
    [RoutePrefix("api/shoppinglists")]
    public class ShoppingListController : ApiController
    {
        IShoppingListService _shopService;
        public ShoppingListController(IShoppingListService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_shopService.GetFamilyShoppingList(new Guid("1E81B125-F117-4040-9DBB-B92E1A034724")));
        }

        //[Authorize]
        [Route("{familyId:Guid}")]
        [HttpGet]
        public IHttpActionResult Get(Guid familyId)
        {
            //TODO: authenticate whether use has access to family shopping list
            return Ok(_shopService.GetFamilyShoppingList(familyId));
        }

        [Route("{familyId:Guid}/items")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] ShoppingListItem item, Guid familyId)
        {
            //TODO: authenticate whether use has access to family shopping list
            var shopItem = _shopService.GetShoppingListItemDetailsByName(item.Name);
            if (shopItem != null)
                return BadRequest("The item is already in the shoppinglist, try updating the existing item.");
            _shopService.AddItemToFamilyShoppingList(familyId, item);
            var returnItem = _shopService.GetShoppingListItemDetailsByName(item.Name);
            return Created(WebConfigurationManager.AppSettings["baseUrl"] + $"api/shoppinglists/{familyId}/items/{returnItem.Id}", returnItem);
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ShoppingListItem item, Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            if (item.Id != null && item.Id != ItemId)
                return BadRequest("Id provided in item is not the same as the one provided in the url.");

            item.Id = ItemId;
            if (_shopService.GetShoppingListItemDetailsById(ItemId) == null)
                return NotFound();

            _shopService.AlterShoppingListItemDetails(familyId, item);
            return Ok(_shopService.GetShoppingListItemDetailsById(ItemId));
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpGet]
        public IHttpActionResult Get(Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            var returnItem = _shopService.GetShoppingListItemDetailsById(ItemId);
            if (returnItem == null)
                return NotFound();

            return Ok(returnItem);
        }
    }
}
