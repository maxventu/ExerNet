using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Exernet.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Task Task { get; set; }
        [Required]
        public virtual ICollection<ApplicationUser> User { get; set; }
        [Required]
        public Boolean Type { get; set; }
    }
}