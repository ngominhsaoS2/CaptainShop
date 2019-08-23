using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaptainShop.Application.Interfaces;
using CaptainShop.WebApi.Authorization;
using CaptainShop.WebApi.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaptainShop.WebApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        IProductCategoryService _productCategoryService;

        public ProductController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        // GET: api/values
        [HttpGet]
        [Route("get")]
        [ClaimRequirement(FunctionCode.Product, PermissionAction.View)]
        public IActionResult Get()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get2")]
        public IActionResult Get2()
        {
            return new OkObjectResult(_productCategoryService.GetAll());
        }

    }
}