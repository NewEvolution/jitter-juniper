using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jitter.Models
{
    public class JitterUser : IComparable
    {
        [Key]
        public int JitterUserId { get; set; }

        public virtual ApplicationUser RealUser { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z\d]+[\w''-']{0,2}[a-zA-Z\d]+")]
        public string Handle { get; set; }

        [MaxLength(161)]
        public string Description { get; set; }

        [RegularExpression(@"[A-Z][a-z]+")]
        public string FirstName { get; set; }

        [RegularExpression(@"[A-Z][a-z]+")]
        public string LastName { get; set; }
        public string Picture { get; set; }

        public List<Jot> Jots { get; set; }
        public List<JitterUser> Following { get; set; }

        public int CompareTo(object obj)
        {
            JitterUser comparator = obj as JitterUser;
            return Handle.CompareTo(comparator.Handle);
        }
    }
}