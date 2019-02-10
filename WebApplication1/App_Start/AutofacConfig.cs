using Autofac;
using Autofac.Integration.Mvc;
using dihiddieDiary.DAL.DiaryPost.Core.Interfaces;
using dihiddieDiary.DAL.DiaryPost.EF.UnitOfWork;
using System.Web.Mvc;


namespace dihiddieDiary
{
    public static class AutofacConfig
    {
        public static void Configure()
        {
            // Autofac
            var builder = new ContainerBuilder();

            SetCoreBindings(builder);
            SetContextBindings(builder);
            SetMvcBindings(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void SetCoreBindings(ContainerBuilder builder)
        {
        }

        private static void SetContextBindings(ContainerBuilder builder)
        {
            builder.RegisterType<DiaryUnitOfWork>().As<IDiaryUnitOfWork>().InstancePerRequest();
        }

        private static void SetMvcBindings(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();
        }
    }
}