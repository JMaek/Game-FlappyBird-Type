using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }

        [Key]
        public int UserId { get; set; }
    }
}
