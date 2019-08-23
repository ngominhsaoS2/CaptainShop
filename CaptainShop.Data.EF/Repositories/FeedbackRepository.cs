using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class FeedbackRepository : EFRepository<Feedback, int>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context) : base(context)
        {
        }
    }
}