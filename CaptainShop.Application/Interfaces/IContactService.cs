using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Application.ViewModels.Common;
using CaptainShop.Utilities.Dtos;

namespace CaptainShop.Application.Interfaces
{
    public interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(string id);

        List<ContactViewModel> GetAll();

        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void SaveChanges();
    }
}