using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplicationUniRegistration.BusinessLayer;
using WebApplicationUniRegistration.DAL;

namespace WebApplicationUniRegistration
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<ICDAL, CDAL>();
            container.RegisterType<IUserDAL, UserDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}