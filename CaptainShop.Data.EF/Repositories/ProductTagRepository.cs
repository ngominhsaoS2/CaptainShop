using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Repositories
{
    public class ProductTagRepository : EFRepository<ProductTag, int>, IProductTagRepository
    {
        public ProductTagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
