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
    [Table("Pages")]
    public class Page : DomainEntity<int>,ISwitchable
    {
        public Page() { }

        public Page(int id, string name, string alias, 
            string content, Status status)
        {
            Id = id;
            Name = name;
            Alias = alias;
            Content = content;
            Status = status;
        }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        [Required]
        public string Alias { get; set; }

        public string Content { get; set; }
        public Status Status { get; set; }
    }
}
