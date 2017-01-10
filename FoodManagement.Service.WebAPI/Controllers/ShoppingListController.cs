using FoodManagement.Core;
using FoodManagement.Core.DTO;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;

namespace FoodManagement.Service.WebAPI.Controllers
{
    [FamilyAuthorize]
    [RoutePrefix("api/shoppinglists")]
    public class ShoppingListController : ApiController
    {
        IShoppingListService _shopService;
        IFamilyService _fService;
        public ShoppingListController(IShoppingListService shopService, IFamilyService fService)
        {
            _shopService = shopService;
            _fService = fService;
        }
        //TODO: find generic way to check authenticate someone (check whether he has access to certain data) for example has a person acces to a shoppinglist
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_shopService.GetFamilyShoppingList(new Guid("1E81B125-F117-4040-9DBB-B92E1A034724")));
        }

        [Route("~/api/itemnames")]
        [HttpGet]
        public IHttpActionResult GetNames(string q)
        {
            IEnumerable<string> names = _shopService.GetShoppingListItemNames(JsonConvert.DeserializeObject<string>(q));
            return Ok(names);
        }

        [Route("~/api/description")]
        [HttpGet]
        public IHttpActionResult GetDescriptions(string q)
        {
            string description = _shopService.GetDescriptionsForItemName(JsonConvert.DeserializeObject<string>(q));
            return Ok(description);
        }

        //[Authorize]
        [Route("{familyId:Guid}")]
        [Route("{familyId:Guid}/items")]
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
            if (IsDefault(item))
                return BadRequest();
            //TODO: authenticate whether use has access to family shopping list
            var shopItem = _shopService.GetShoppingListItemDetailsByName(familyId, item.Name);
            if (shopItem != null)
                return BadRequest("The item is already in the shoppinglist, try updating the existing item.");
            _shopService.AddItemToFamilyShoppingList(familyId, item);
            var returnItem = _shopService.GetShoppingListItemDetailsByName(familyId, item.Name);
            return Created(WebConfigurationManager.AppSettings["baseUrl"] + $"api/shoppinglists/{familyId}/items/{returnItem.Id}", returnItem);
        }

        [Route("{familyId:Guid}/items")]
        [HttpPatch]
        public IHttpActionResult Patch([FromBody]JsonPatchDocument<ICollection<ShoppingListItem>> patchDoc, Guid familyId)
        {
            if (patchDoc.Operations.FirstOrDefault(o => o.path == "/AreBought" && Convert.ToBoolean(o.value)) != null)
                _shopService.MarkAllShoppingListItemsAsBought(familyId);
            return Ok();
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
        [HttpPatch]
        public IHttpActionResult Patch([FromBody]JsonPatchDocument<ShoppingListItem> patchDoc , Guid familyId, Guid itemId)
        {
            var sli = _shopService.GetShoppingListItemDetailsById(familyId, itemId);
            if(patchDoc.Operations.FirstOrDefault(o => o.path == "/IsBought" && Convert.ToBoolean(o.value)) != null)
                _shopService.MarkShoppingListItemAsBought(familyId, sli.Id);
            return Ok();
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpPut]
        public IHttpActionResult Put([FromBody] ShoppingListItem item, Guid familyId, Guid ItemId)
        {
            if(IsDefault(item))
                return BadRequest();
            //TODO: authenticate whether use has access to family shopping list
            if (item.Id != default(Guid) && item.Id != ItemId)
                return BadRequest("Id provided in item is not the same as the one provided in the url.");

            item.Id = ItemId;
            if (_shopService.GetShoppingListItemDetailsById(familyId, ItemId) == null)
                return NotFound();

            _shopService.AlterShoppingListItemDetails(familyId, item);

            return Ok(_shopService.GetShoppingListItemDetailsById(familyId, ItemId));
        }

        [Route("{familyId:Guid}/items/{itemId:Guid}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid familyId, Guid ItemId)
        {
            //TODO: authenticate whether use has access to family shopping list
            var returnItem = _shopService.GetShoppingListItemDetailsById(familyId, ItemId);
            if (returnItem == null)
                return NotFound();
            _shopService.RemoveShoppingListItemForFamily(familyId, ItemId);
            return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        private bool IsDefault<T>(T DTO) where T : class
        {
            if (DTO == default(T))
                return true;
            var defaultInstance = Activator.CreateInstance(DTO.GetType());
            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.PropertyType.IsValueType)
                {
                    var b = prop.GetValue(defaultInstance).ToString();
                    var c = prop.GetValue(DTO).ToString();
                    if (b != c)
                        return false;
                }
                else
                {
                    var b = prop.GetValue(defaultInstance);
                    var c = prop.GetValue(DTO);
                    if (b != c)
                        return false;
                }
            }
            return true;
        }
    }
}
