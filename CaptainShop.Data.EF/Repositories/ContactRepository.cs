using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;

namespace CaptainShop.Data.EF.Repositories
{
    public class ContactRepository : EFRepository<Contact, string>, IContactRepository
    {
        public ContactRepository(AppDbContext context) : base(context)
        {
        }
    }
}