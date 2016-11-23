using FoodManagement.Core;
using FoodManagement.Core.DTO;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        //TODO: find generic way to check authenticate someone (check whether he has access to certain data) for example has a person acces to a shoppinglist
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
            var shopItem = _shopService.GetShoppingListItemDetailsByName(familyId, item.Name);
            if (shopItem != null)
                return BadRequest("The item is already in the shoppinglist, try updating the existing item.");
            _shopService.AddItemToFamilyShoppingList(familyId, item);
            var returnItem = _shopService.GetShoppingListItemDetailsByName(familyId, item.Name);
            return Created(WebConfigurationManager.AppSettings["baseUrl"] + $"api/shoppinglists/{familyId}/items/{returnItem.Id}", returnItem);
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ShoppingListItem item, Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            if (item.Id != default(Guid) && item.Id != ItemId)
                return BadRequest("Id provided in item is not the same as the one provided in the url.");

            item.Id = ItemId;
            if (_shopService.GetShoppingListItemDetailsById(familyId, ItemId) == null)
                return NotFound();

            _shopService.AlterShoppingListItemDetails(familyId, item);

            if (item.Bought)
                _shopService.MarkShoppingListItemAsBought(familyId, item.Id);

            return Ok(_shopService.GetShoppingListItemDetailsById(familyId, ItemId));
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpGet]
        public IHttpActionResult Get(Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            var returnItem = _shopService.GetShoppingListItemDetailsById(familyId, ItemId);
            if (returnItem == null)
                return NotFound();

            return Ok(returnItem);
        }
        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            var returnItem = _shopService.GetShoppingListItemDetailsById(familyId, ItemId);
            if (returnItem == null)
                return NotFound();

            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }
    }
}
