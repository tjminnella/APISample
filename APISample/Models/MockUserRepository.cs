using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _UserList;

        public MockUserRepository()
        {
            _UserList = new List<User>()
            {
                new User(){Id = 1, UserName = "Thomas Minnella", UserID = "tminnella", UserPwd = "qwerty"},
                new User(){Id = 2, UserName = "Mark Pineda", UserID = "password", UserPwd = "123"}
            };
        }

        public User GetUser(string UserID, string UserPwd)
        {
            //var user = _UserList.Where(a => a.UserID.Equals(UserID) && a.UserPwd.Equals(UserPwd)).FirstOrDefault();
            var user = _UserList.FirstOrDefault(x => x.UserID == UserID && x.UserPwd == UserPwd);
            return user;
        }
    }
}
