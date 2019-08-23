using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaptainShop.Application.Interfaces;
using CaptainShop.Application.ViewModels.Blog;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using CaptainShop.Infrastructure.Interfaces;
using CaptainShop.Utilities.Dtos;

namespace CaptainShop.Application.Implementation
{
    public class PageService : IPageService
    {
        private IPageRepository _pageRepository;
        private IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            _pageRepository = pageRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(PageViewModel pageVm)
        {
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Add(page);
        }

        public void Delete(int id)
        {
            _pageRepository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<PageViewModel> GetAll()
        {
            return _pageRepository.FindAll().ProjectTo<PageViewModel>().ToList();
        }

        public PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _pageRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Alias)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<PageViewModel>()
            {
                Results = data.ProjectTo<PageViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };

            return paginationSet;
        }

        public PageViewModel GetByAlias(string alias)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.FindSingle(x => x.Alias == alias));
        }

        public PageViewModel GetById(int id)
        {
            return Mapper.Map<Page, PageViewModel>(_pageRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
        public void Update(PageViewModel pageVm)
        {
            var page = Mapper.Map<PageViewModel, Page>(pageVm);
            _pageRepository.Update(page);
        }
    }
}