﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exernet.Models
{
    public class Solution
    {
        public int Id { get; set; }
        public Task Task { get; set; }
        public virtual ICollection<ApplicationUser> User { get; set; }
        public DateTime UploadDate { get; set; }
        public string Text { get; set; }
        public bool Correct { get; set; }
        public int Points  { get; set; }
    }
}