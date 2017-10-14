[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Reverb.Web.App_Start.NinjectConfiguration), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Reverb.Web.App_Start.NinjectConfiguration), "Stop")]

namespace Reverb.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using Data.Contracts;
    using Data;
    using System.Data.Entity;
    using Data.Repositories;
    using Services.Contracts;
    using Services;
    using Data.SaveChanges;

    public static class NinjectConfiguration
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //kernel.Bind(x =>
            //{
            //    x.FromThisAssembly()
            //        .SelectAllClasses()
            //        .BindDefaultInterface();
            //});

            kernel.Bind<DbContext, IReverbDbContext>().To<ReverbDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfContextWrapper<>)).To(typeof(EfContextWrapper<>));
            kernel.Bind<ISaveContext>().To<SaveContext>().InRequestScope();
            
            kernel.Bind<ISongService>().To<SongService>().InRequestScope();
            kernel.Bind<IUserService>().To<UserService>().InRequestScope();
        }        
    }
}