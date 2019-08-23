using System.Collections.Generic;
using CaptainShop.Application.ViewModels.Blog;
using CaptainShop.Application.ViewModels.Common;
using CaptainShop.Application.ViewModels.Product;
using TeduCoreApp.Application.ViewModels.Blog;

namespace CaptainShop.Models
{
    public class HomeViewModel
    {
        public List<BlogViewModel> LastestBlogs { get; set; }

        public List<SlideViewModel> HomeSlides { get; set; }

        public List<ProductViewModel> HotProducts { get; set; }

        public List<ProductViewModel> TopSellProducts { get; set; }

        public List<ProductCategoryViewModel> HomeCategories { set; get; }

        public string Title { set; get; }

        public string MetaKeyword { set; get; }

        public string MetaDescription { set; get; }
    }
}
