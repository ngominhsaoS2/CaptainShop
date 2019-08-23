using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CaptainShop.Infrastructure.SharedKernel;

namespace CaptainShop.Data.Entities
{
    [Table("Permissions")]
    public class Permission : DomainEntity<int>
    {
        public Permission()
        {

        }

        public Permission(Guid roleId, string functionId, bool canCreate,
            bool canRead, bool canUpdate, bool canDelete)
        {
            RoleId = roleId;
            FunctionId = functionId;
            CanCreate = canCreate;
            CanRead = canRead;
            CanUpdate = canUpdate;
            CanDelete = canDelete;
        }

        [Required]
        public Guid RoleId { get; set; }

        [StringLength(128)]
        [Column(TypeName = "varchar(128)")]
        [Required]
        public string FunctionId { get; set; }

        public bool CanCreate { get; set; }

        public bool CanRead { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { get; set; }

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }
    }
}
