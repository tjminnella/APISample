using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Models
{
    public interface IUserRepository
    {
        public User GetUser(string UserID, string UserPwd);
    }
}
