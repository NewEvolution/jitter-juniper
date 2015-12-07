using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jitter.Models
{
    public class Jot : IComparable
    {
        [Key]
        public int JotId { get; set; }
        public virtual JitterUser Author { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Picture { get; set; }

        public int CompareTo(object obj)
        {
            Jot comparator = obj as Jot;
            return -1 * Date.CompareTo(comparator.Date);
        }
    }
}