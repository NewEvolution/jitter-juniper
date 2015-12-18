using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public Jot GetJotById(JitterUser user, int jot_id)
        {
            // IQueryable that contains a single JitterUser
            var query = from u in _context.JitterUsers where u.JitterUserId == user.JitterUserId select u;
            JitterUser found_user = query.Single<JitterUser>();
            var query2 = from jot in found_user.Jots where jot.JotId == jot_id select jot;
            Jot found_jot = query2.Single<Jot>();
            return found_jot;

        }

        public List<Jot> GetUserJots(JitterUser user)
        {
            var query = from u in _context.JitterUsers where u.JitterUserId == user.JitterUserId select u;
            JitterUser found_user = query.Single<JitterUser>();
            return found_user.Jots;
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

        public List<JitterUser> SearchByName(string name)
        {
            var query = from users in _context.JitterUsers select users;
            List<JitterUser> foundUsers = query.Where(user => Regex.IsMatch(user.FirstName, name, RegexOptions.IgnoreCase)|| Regex.IsMatch(user.LastName, name, RegexOptions.IgnoreCase)).ToList();
            foundUsers.Sort();
            return foundUsers;
        }

        public List<Jot> GetAllJots()
        {
            var query = from jots in _context.Jots select jots;
            return query.ToList();
        }

        public bool CreateJot(JitterUser jitter_user, string jot_content)
        {
            Jot new_jot = new Jot { Author = jitter_user, Content = jot_content, Date = DateTime.Now };
            try
            {
                Jot added_jot = _context.Jots.Add(new_jot);
                _context.SaveChanges();
                return added_jot != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreateJitterUser(ApplicationUser _user, string handle)
        {
            bool handle_available = IsHandleAvailable(handle);
            if (!handle_available)
            {
                return false;
            }
            JitterUser new_jitter_user = new JitterUser { Handle = handle, RealUser = _user };
            try
            {
                JitterUser added_jitter_user = _context.JitterUsers.Add(new_jitter_user);
                _context.SaveChanges();
                return added_jitter_user != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}