using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaptainShop.Application.Interfaces;
using CaptainShop.Application.ViewModels.Blog;
using CaptainShop.Application.ViewModels.Common;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using CaptainShop.Infrastructure.Interfaces;
using CaptainShop.Utilities.Constants;
using CaptainShop.Utilities.Dtos;
using CaptainShop.Utilities.Helpers;

namespace CaptainShop.Application.Implementation
{
    public class CommonService : ICommonService
    {
        IFooterRepository _footerRepository;
        ISystemConfigRepository _systemConfigRepository;
        IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        public CommonService(IFooterRepository footerRepository, ISystemConfigRepository systemConfigRepository,
                             ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            return Mapper.Map<Footer, FooterViewModel>(_footerRepository.FindSingle(x => x.Id ==
            CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return Mapper.Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository.FindSingle(x => x.Id == code));
        }
    }
}
