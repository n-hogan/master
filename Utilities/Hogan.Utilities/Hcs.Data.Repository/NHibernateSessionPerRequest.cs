using System;
using System.Web;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace Hcs.Data.Repository
{
    public class NHibernateSessionPerRequest : IHttpModule
    {
        private static readonly ISessionFactory SessionFactory;

        // Constructs our HTTP module
        static NHibernateSessionPerRequest()
        {
            SessionFactory = CreateSessionFactory();
        }

        // Initializes the HTTP module
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        // Disposes the HTTP module
        public void Dispose()
        {
        }

        // Returns the current session
        public static ISession GetCurrentSession()
        {
            return SessionFactory.GetCurrentSession();
        }

        // Opens the session, begins the transaction, and binds the session
        private static void BeginRequest(object sender, EventArgs e)
        {
            ISession session = SessionFactory.OpenSession();

            session.BeginTransaction();

            CurrentSessionContext.Bind(session);
        }

        // Unbinds the session, commits the transaction, and closes the session
        private static void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(SessionFactory);

            if (session == null) return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }

        // Returns our session factory
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(CreateDbConfig)
                .Mappings(m => m.AutoMappings.Add(CreateAutoMappings()))
                //.ExposeConfiguration(ConfigureEnvers)

                //.ExposeConfiguration(x => x.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new AuditEventListener() })
                //.ExposeConfiguration(x => x.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new AuditEventListener() })


                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .CurrentSessionContext<WebSessionContext>()
                .BuildSessionFactory();
        }

        //private static void ConfigureEnvers(Configuration configuration)
        //{
        //    var enversConf = new NHibernate.Envers.Configuration.Fluent.FluentConfiguration();

        //    //enversConf.Audit<RevisionAuditableEntity>();


        //    configuration.IntegrateWithEnvers(enversConf);
        //}

        // Returns our database configuration
        private static MsSqlConfiguration CreateDbConfig()
        {
            return MsSqlConfiguration
                .MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey("HcsDatabase"));
        }

        // Returns our mappings
        private static AutoPersistenceModel CreateAutoMappings()
        {
            //return AutoMap
            //    .AssemblyOf<AutomappingConfiguration>(new AutomappingConfiguration());

            return AutoMap
                .AssemblyOf<Entities.Entity>()
                .Where(t => t.Namespace != null && t.Namespace.EndsWith("Entities"))
                .IgnoreBase<Entities.Entity>()
                .Conventions.Setup(c => c.Add(DefaultCascade.SaveUpdate()));
        }

        public class AutomappingConfiguration : DefaultAutomappingConfiguration
        {
            public override bool ShouldMap(Type type)
            {
                return type.Namespace != null && type.Namespace.EndsWith("Entities");
            }
        }


    }
}