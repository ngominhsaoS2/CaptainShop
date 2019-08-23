using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.Enums;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class BlogRepository : EFRepository<Blog, int>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }
    }
}
