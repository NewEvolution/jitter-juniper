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
            var query = from users in _context.JitterUsers select users;
            return query.ToList();
        }

        public JitterUser GetUserByHandle(string handle)
        {
            var query = from user in _context.JitterUsers where user.Handle == handle select user;
            return query.SingleOrDefault();
        }

        public bool IsHandleAvailable(string handle)
        {
            bool available = false;
            try
            {
                JitterUser possibleUser = GetUserByHandle(handle);
                if (possibleUser == null) available = true;
            }
            catch (InvalidOperationException) {}
            return available;
        }

        public List<JitterUser> SearchByHandle(string handle)
        {
            var query = from users in _context.JitterUsers select users;
            List<JitterUser> foundUsers = query.Where(user => user.Handle.Contains(handle)).ToList();
            foundUsers.Sort();
            return foundUsers;
        }
    }
}