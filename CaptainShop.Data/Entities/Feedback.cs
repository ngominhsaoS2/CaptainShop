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
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<int>,ISwitchable, IDateTracking
    {
        public Feedback() { }

        public Feedback(int id, string name, string email, string message, Status status)
        {
            Id = id;
            Name = name;
            Email = email;
            Message = message;
            Status = status;
        }
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
