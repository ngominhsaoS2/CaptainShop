using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Data.Entities;
using CaptainShop.Infrastructure.Interfaces;

namespace CaptainShop.Data.IRepositories
{
    public interface IContactRepository : IRepository<Contact, string>
    {
    }
}