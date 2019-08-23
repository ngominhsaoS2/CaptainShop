using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Repositories
{
    public class WholePriceRepository : EFRepository<WholePrice, int>, IWholePriceRepository
    {
        public WholePriceRepository(AppDbContext context) : base(context)
        {
        }
    }
}
