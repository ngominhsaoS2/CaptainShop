﻿using CaptainShop.Data.Entities;
using CaptainShop.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.IRepositories
{
    public interface ITagRepository : IRepository<Tag, string>
    {
    }
}
