using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class SizeRepository : EFRepository<Size, int>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
