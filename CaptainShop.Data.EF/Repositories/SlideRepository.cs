using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class SlideRepository : EFRepository<Slide, int>, ISlideRepository
    {
        public SlideRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
