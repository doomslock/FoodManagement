using FoodManagement.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FoodManagement.Service.WebAPI
{
    public class FamilyAuthorizeAttribute : AuthorizeAttribute
    {
        IFamilyService _fService;
        public FamilyAuthorizeAttribute()
        {
            _fService = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IFamilyService)) as IFamilyService;
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            object value;
            value = actionContext.RequestContext.RouteData.Values.First(d => d.Key == "familyId").Value;
            if (value == null)
                return true;
            Guid familyId = new Guid((string)value);
            
            return _fService.PersonIsAuthorizedToFamily(new Guid("D38A4709-4D0A-434B-905B-1ADACB7B015E"),familyId); //TODO: use logged on user id
        }
    }
}