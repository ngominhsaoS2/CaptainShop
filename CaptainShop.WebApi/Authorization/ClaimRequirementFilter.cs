using CaptainShop.WebApi.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptainShop.WebApi.Authorization
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly FunctionCode _functionCode;
        private readonly PermissionAction _permissionAction;

        public ClaimRequirementFilter(FunctionCode functionCode, PermissionAction permissionAction)
        {
            _functionCode = functionCode;
            _permissionAction = permissionAction;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var authHeader = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationToken);



            //var base64Url = authorizationToken.ToString().Split(".")[0];
            //var base64 = base64Url.Replace("-", "+").Replace("_", "/");
            //var base64EncodedBytes = System.Convert.FromBase64String(base64);
            //var saonm = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

            //var user = JsonConvert.DeserializeObject(saonm);


            var permissionsClaim = context.HttpContext.User.Claims.SingleOrDefault(x => x.Type == "permissions");
            if(permissionsClaim != null)
            {
                var permisions = JsonConvert.DeserializeObject<List<string>>(permissionsClaim.Value);
                if (!permisions.Contains("product"))
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
