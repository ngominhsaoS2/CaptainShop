using CaptainShop.Data.Entities;
using CaptainShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory, int>
    {
        List<ProductCategory> GetByAlias(string alias);
    }
}
