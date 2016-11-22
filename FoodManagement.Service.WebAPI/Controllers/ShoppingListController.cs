using FoodManagement.Core;
using FoodManagement.Core.Model;
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
            return Ok(_shopService.GetFamilyShoppingList(familyId));
        }

        [Route("{familyId:Guid}/items")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] ShoppingListItem item, Guid familyId)
        {
            //TODO: authenticate whether use has access to family shopping list
            item.Id = Guid.NewGuid();
            var a = _shopService.GetShoppingListItemDetailsByName(item.Item.Name);
            if (a != null)
                BadRequest();
            _shopService.AddItemToFamilyShoppingList(familyId, item);
            var returnItem = _shopService.GetShoppingListItemDetailsById(item.Id);
            return Created(WebConfigurationManager.AppSettings["baseUrl"] + $"api/shoppinglist/{familyId}/items/{returnItem.Id}", returnItem);
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ShoppingListItem item, Guid familyId, Guid ItemId)
        {
            if (item.Id != null && item.Id != ItemId)
                return BadRequest();

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
            var returnItem = _shopService.GetShoppingListItemDetailsById(ItemId);
            if (returnItem == null)
                return NotFound();

            return Ok(returnItem);
        }
    }
}
