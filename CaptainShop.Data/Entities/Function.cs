using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CaptainShop.Data.Enums;
using CaptainShop.Data.Interfaces;
using CaptainShop.Infrastructure.SharedKernel;

namespace CaptainShop.Data.Entities
{
    [Table("Functions")]
    public class Function : DomainEntity<string>, ISwitchable, ISortable
    {
        public Function()
        {

        }
        public Function(string name, string url, string parentId, string iconCss, int sortOrder)
        {
            Name = name;
            URL = url;
            ParentId = parentId;
            IconCss = iconCss;
            SortOrder = sortOrder;
            Status = Status.Active;
        }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string URL { get; set; }


        [StringLength(128)]
        public string ParentId { get; set; }

        public string IconCss { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }
    }
}
