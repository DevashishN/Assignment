using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplicationUniRegistration.BL.BusinessLayer;
using WebApplicationUniRegistration.DAL.DataAccessLayer;

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
            container.RegisterType<IAdminBL, AdminBL>();
            container.RegisterType<IAdminDAL, AdminDAL>();
            container.RegisterType<IRoleBL, RoleBL>();
            container.RegisterType<IRoleDAL, RoleDAL>();
            container.RegisterType<IResultBL, ResultBL>();
            container.RegisterType<IResultDAL, ResultDAL>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}