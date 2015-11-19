using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jitter.Models
{
    public class Jot
    {
        [Key]
        public int JotId { get; set; }
        public object Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }
    }
}