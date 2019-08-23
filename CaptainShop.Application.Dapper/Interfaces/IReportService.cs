﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CaptainShop.Application.Dapper.ViewModels;

namespace CaptainShop.Application.Dapper.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
    }
}