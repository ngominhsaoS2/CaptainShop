using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Repositories
{
    public class ProductQuantityRepository : EFRepository<ProductQuantity, int>, IProductQuantityRepository
    {
        public ProductQuantityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
