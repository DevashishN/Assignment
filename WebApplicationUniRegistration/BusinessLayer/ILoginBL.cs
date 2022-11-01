using WebApplicationUniRegistration.Models;

namespace WebApplicationUniRegistration.BusinessLayer
{
    public interface ILoginBL
    {
        User Authenticate(string email, string password);
    }
}