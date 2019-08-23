using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaptainShop.Application.ViewModels.Common;

namespace CaptainShop.Models
{
    public class ContactPageViewModel
    {
        public ContactViewModel Contact { set; get; }

        public FeedbackViewModel Feedback { set; get; }
    }
}