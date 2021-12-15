﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Authorization
{
    public class UserRole
    {
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
