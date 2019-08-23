using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class FooterRepository : EFRepository<Footer, string>, IFooterRepository
    {
        public FooterRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
