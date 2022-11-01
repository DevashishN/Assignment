using WebApplicationUniRegistration.Models;
using WebApplicationUniRegistration.DAL;
using System.Web.Helpers;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public class LoginBL : ILoginBL
    {
        private readonly ILoginDAL _userDAL;
        public LoginBL(ILoginDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public User Authenticate(string email, string password)
        {
            User user = _userDAL.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }

            if (!Crypto.VerifyHashedPassword(user.Password, password))
            {
                return null;
            }

            return user;
        }
    }
}