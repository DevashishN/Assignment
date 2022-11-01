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
            container.RegisterType<ILoginBL, LoginBL>();
            container.RegisterType<IConnectionDAL, ConnectionDAL>();
            container.RegisterType<ILoginDAL, LoginDAL>();
            container.RegisterType<IRegisterBL, RegisterBL>();
            container.RegisterType<IRegisterDAL, RegisterDAL>();
            container.RegisterType<IStudentBL, StudentBL>();
            container.RegisterType<IStudentDAL, StudentDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}