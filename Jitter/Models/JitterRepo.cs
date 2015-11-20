using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace Jitter.Models
{
    public class JitterRepo
    {
        private JitterContext _context;
        public JitterContext Context {get { return _context;}}

        public JitterRepo()
        {
            _context = new JitterContext();
        }

        public JitterRepo(JitterContext context)
        {
            _context = context;
        }

        public List<JitterUser> GetAllUsers()
        {
            return null;
        }
    }
}