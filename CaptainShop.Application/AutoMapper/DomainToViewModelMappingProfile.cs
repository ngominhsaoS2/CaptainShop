using AutoMapper;
using CaptainShop.Application.ViewModels.Blog;
using CaptainShop.Application.ViewModels.Common;
using CaptainShop.Application.ViewModels.Product;
using CaptainShop.Application.ViewModels.System;
using CaptainShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using TeduCoreApp.Application.ViewModels.Blog;

namespace CaptainShop.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>().MaxDepth(2);
            CreateMap<Function, FunctionViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<Bill, BillViewModel>().MaxDepth(2);
            CreateMap<BillDetail, BillDetailViewModel>().MaxDepth(2);
            CreateMap<Color, ColorViewModel>().MaxDepth(2);
            CreateMap<Size, SizeViewModel>().MaxDepth(2);
            CreateMap<ProductQuantity, ProductQuantityViewModel>().MaxDepth(2);
            CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);
            CreateMap<WholePrice, WholePriceViewModel>().MaxDepth(2);
            CreateMap<Blog, BlogViewModel>().MaxDepth(2);
            CreateMap<BlogTag, BlogTagViewModel>().MaxDepth(2);
            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<SystemConfig, SystemConfigViewModel>().MaxDepth(2);
            CreateMap<Footer, FooterViewModel>().MaxDepth(2);
            CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<Page, PageViewModel>().MaxDepth(2);
        }
    }
}