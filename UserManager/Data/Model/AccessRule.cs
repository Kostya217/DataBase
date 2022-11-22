﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security;
using UserManager.Data.Enum;

namespace UserManager.Data.Model
{
    [Table("Access Rule")]
    public class AccessRule
    {
        [Key]
        public int AccessRuleId { get; set; }

        [Required]
        public string Path { get; set; } = null!;

        public Permission Copy { get; set; }

        public Permission Download { get; set; }

        public Permission Write { get; set; }

        public Permission Read { get; set; }

        public Permission WriteContents { get; set; }

        public Permission Upload { get; set; }

        public bool IsFile { get; set; }

        [ForeignKey("AccessRole")]
        public int AccessRoleId { get; set; }
        public virtual AccessRole AccessRole { get; set; }
    }
}
