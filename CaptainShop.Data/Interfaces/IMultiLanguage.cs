﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.Interfaces
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { get; set; }
    }
}
