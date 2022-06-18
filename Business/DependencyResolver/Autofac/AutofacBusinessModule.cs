using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concreate;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Secure.Jwt;
using DataAccess.Abstract;
using DataAccess.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDalPostgres>().As<IProductDal>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserDalDapper>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

            builder.RegisterType<TokenHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                  .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                  {
                      Selector = new AspectInterceptorSelector()
                  });
        }
    }
}
