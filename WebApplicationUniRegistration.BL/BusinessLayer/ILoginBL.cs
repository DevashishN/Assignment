using WebApplicationUniRegistration.DAL.Models;

namespace WebApplicationUniRegistration.BL.BusinessLayer
{
    public interface ILoginBL
    {
        User Authenticate(string email, string password);
    }
}