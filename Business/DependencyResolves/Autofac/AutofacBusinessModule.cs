using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoorManager>().As<IDoorService>().SingleInstance();
            builder.RegisterType<DoorDal>().As<IDoorDal>().SingleInstance();
            builder.RegisterType<DoorRoleManager>().As<IDoorRoleService>().SingleInstance();
            builder.RegisterType<DoorRoleDal>().As<IDoorRoleDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserTypeManager>().As<IUserTypeService>().SingleInstance();
            builder.RegisterType<UserTypeDal>().As<IUserTypeDal>().SingleInstance();
            builder.RegisterType<UserValidationDoorManager>().As<IUserValidationDoorService>().SingleInstance();
            builder.RegisterType<UserValidationDoorDal>().As<IUserValidationDoorDal>().SingleInstance();
            builder.RegisterType<VerificationManager>().As<IVerificationService>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
