using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaptainShop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaptainShop.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("page/{alias}.html", Name = "Page")]
        public IActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            return View(page);
        }
    }
}