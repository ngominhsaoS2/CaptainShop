using CaptainShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaptainShop.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; } 
    }
}
