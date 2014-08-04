using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exernet.Models
{
    public class Comment {
        [Key]
        public int Id { get; set; }
        [Required]
        public ExernetTask Task { get; set; }
        [Required]
        public virtual ICollection<ApplicationUser> User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Text { get; set; }
    }
}