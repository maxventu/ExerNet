using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exernet.Models
{
    public class Chart
    {
        public int Id { get; set; }
        public Task Task { get; set; }
        public string ChartURL { get; set; }
    }
}