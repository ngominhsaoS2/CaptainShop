﻿using System;
using System.Collections.Generic;
using System.Text;
using CaptainShop.Application.ViewModels.Common;

namespace CaptainShop.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();

        List<SlideViewModel> GetSlides(string groupAlias);

        SystemConfigViewModel GetSystemConfig(string code);
    }
}
