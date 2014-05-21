using DidYouFall.App_Start;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DidYouFall
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static ISessionFactory SessionFactory { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            SessionFactory = Fluently.Configure()
              .Database(
                MySQLConfiguration.Standard.ConnectionString
                ("Server=localhost;Database=didyoufall;Uid=root;Pwd=admin;").ShowSql().FormatSql())
                .Mappings(i => i.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .ExposeConfiguration(c => c.Properties.Add("hbm2ddl.keywords", "none"))
                .ExposeConfiguration(c => new SchemaUpdate(c).Execute(true, true))
                .BuildSessionFactory();

            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);


        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Dispose();

        }
    }
}
