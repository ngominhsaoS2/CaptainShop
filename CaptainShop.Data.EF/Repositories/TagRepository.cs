using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Repositories
{
    public class TagRepository : EFRepository<Tag, string>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
