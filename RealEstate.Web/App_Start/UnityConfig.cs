using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealEstate.Data.Contexts;
using RealEstate.Data.Repository;
using RealEstate.Data.Repository.IRepository;
using RealEstate.Model;
using RealEstate.Web.Controllers;
using System;
using System.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace RealEstate.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            container.RegisterType<AccountController>(new InjectionConstructor());
            //container.RegisterType<UserManager<RealEstateUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<RealEstateUser>, UserStore<RealEstateUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<RealEstateContext>(new InjectionConstructor(new object[] { ConfigurationManager.ConnectionStrings["RealEstateConnection"].ToString() }));
            container.RegisterType<IRealEstateContext, RealEstateContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IRealEstatePropertyRepository, RealEstatePropertyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRealEstatePropertyInterestRepository, RealEstatePropertyInterestRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRealEstateNotificationRepository, RealEstateNotificationRepository>(new HierarchicalLifetimeManager());

        }
    }
}