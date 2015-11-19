using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jitter.Models
{
    public class JitterUser
    {
        [Key]
        public int JitterUserId { get; set; }
        [MaxLength(161)]
        public string Description { get; set; }
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z\d]+[\w''-']{0,2}[a-zA-Z\d]+", ErrorMessage = "Only ")]
        public string Handle { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
    }
}