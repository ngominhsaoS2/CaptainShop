using CaptainShop.Data.Entities;
using CaptainShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.EF.Repositories
{
    public class PermissionRepository : EFRepository<Permission, int>, IPermissionRepository
    {
        public PermissionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
