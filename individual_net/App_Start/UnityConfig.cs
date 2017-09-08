using individual_net.Models;
using individual_net.Repository;
using individual_net.Service;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Unity.WebApi;

namespace individual_net
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.AddNewExtension<Interception>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUsuarioRepository, UsuarioRepository>();
            container.RegisterType<IUsuarioService, UsuarioService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IRecursoRepository, RecursoRepository>();
            container.RegisterType<IRecursoService, RecursoService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IPrestamoRepository, PrestamoRepository>();
            container.RegisterType<IPrestamoService, PrestamoService>(
              new Interceptor<InterfaceInterceptor>(),
              new InterceptionBehavior<LoggingInterceptionBehavior>());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }

    class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public IMethodReturn Invoke(IMethodInvocation input,
              GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn result;
            if (ApplicationDbContext.applicationDbContext == null)
            {
                using (var context = new ApplicationDbContext())
                {
                    ApplicationDbContext.applicationDbContext = context;
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            result = getNext()(input, getNext);
                            if (result.Exception != null)
                            {
                                throw result.Exception;
                            }

                            context.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                        catch (Exception e)
                        {
                            dbContextTransaction.Rollback();
                            ApplicationDbContext.applicationDbContext = null;
                            throw new Exception("He hecho rollback de la transacci�n", e);
                        }
                    }
                }
                ApplicationDbContext.applicationDbContext = null;
                return result;
            }
            else
            {
                result = getNext()(input, getNext);
                if (result.Exception != null)
                {
                    throw new Exception("Ocurri� una excepci�n" + result.Exception);
                }
                return result;
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void WriteLog(string message)
        {

        }
    }
}