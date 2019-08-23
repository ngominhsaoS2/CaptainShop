using CaptainShop.WebApi.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaptainShop.WebApi.Authorization
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(FunctionCode functionCode, PermissionAction permissionAction) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { functionCode, permissionAction };
        }
    }
}
