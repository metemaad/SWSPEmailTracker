using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Cfg.Loquacious;
using NHibernate.Validator.Engine;
using Configuration = NHibernate.Cfg.Configuration;

namespace SWSPET.BL.Infrastructure
{

        public class DataAccess
        {
            public static string ConnectionString { get; set; }
            public static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory != null && !_sessionFactory.IsClosed)
                    {
                        return _sessionFactory;
                    }
                    else
                    {
                        _sessionFactory = CreateSessionFactory();
                        return _sessionFactory;
                    }
                }
            }

            private static ValidatorEngine validator;
            public static ValidatorEngine Validator
            {
                get
                {
                    if (validator == null)
                    {
                        validator = new ValidatorEngine();
                        var nhvConfig = InitializeValidationEngine();
                        validator.Configure(nhvConfig);
                    }
                    return validator;
                }
            }

            public static ISession NhSession
            {
                get
                {
                    if (_nhSession != null && _nhSession.IsOpen)
                        return _nhSession;
                    else
                    {
                        _nhSession = SessionFactory.OpenSession();
                        return _nhSession;
                    }
                }
            }

            private static ISession _nhSession;
            private static ISessionFactory _sessionFactory;
            public static void CreateDatabase()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                Fluently.Configure()
                    .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(CreateSchema)
                    .BuildConfiguration();
            }

            private static NHibernate.Validator.Cfg.Loquacious.FluentConfiguration InitializeValidationEngine()
            {
                var nhvConfig =
                    new NHibernate.Validator.Cfg.Loquacious.FluentConfiguration();
                nhvConfig
                    .SetDefaultValidatorMode(ValidatorMode.UseAttribute)
                    .Register(typeof(DataAccess).Assembly.ValidationDefinitions())
                    .IntegrateWithNHibernate
                    .AvoidingDDLConstraints()
                    .And
                    .RegisteringListeners();

                return nhvConfig;
            }

            private static void CreateSchema(Configuration cfg)
            {
                var schemaExport = new SchemaExport(cfg);
                schemaExport.Drop(false, true);
                schemaExport.Create(false, true);
            }

            public static void UpdateDatabase()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                CreateSessionFactory();
                Fluently.Configure()
                     .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(UpdateSchema)
                    .BuildConfiguration();
            }

            private static void UpdateSchema(Configuration cfg)
            {
                var schemaUpdate = new SchemaUpdate(cfg);
                schemaUpdate.Execute(false, true);

            }

            private static ISessionFactory CreateSessionFactory()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
                var config = Fluently.Configure()
                    .Database(MsSqlConfiguration
                                  .MsSql2008
                                  .ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
                    .ExposeConfiguration(UpdateSchema)
                    .BuildConfiguration();
                config.Initialize(Validator);
                return config.BuildSessionFactory();
            }

            public static void Flush()
            {
                NhSession.Close();
            }
        }




    //public class DataAccessMThread
    //{
    //    public static string ConnectionString { get; set; }
    //    private static Mutex _sessionFactoryMutex = new Mutex();
    //    private static Mutex _sessionMutex = new Mutex();

    //    public static ISessionFactory SessionFactory
    //    {
    //        get
    //        {
    //            ISessionFactory sessionFactory;
    //            try
    //            {

    //                _sessionMutex.WaitOne();
                    
    //                if (_sessionFactoryDistionry == null)
    //                {
    //                    sessionFactory = CreateSessionFactory();
    //                    _sessionFactoryDistionry[Thread.CurrentThread.ManagedThreadId] = sessionFactory;

    //                }
    //                using (
    //                    ISessionFactory _sessionFactory = _sessionFactoryDistionry[Thread.CurrentThread.ManagedThreadId]
    //                    )
    //                {
    //                    try
    //                    {
    //                        if (_sessionFactory != null && !_sessionFactory.IsClosed)
    //                        {
    //                            sessionFactory = _sessionFactory;
    //                        }
    //                        else
    //                        {
    //                            sessionFactory = CreateSessionFactory();
    //                            _sessionFactoryDistionry[Thread.CurrentThread.ManagedThreadId] = sessionFactory;
    //                        }
    //                    }
    //                    catch (Exception exception)
    //                    {
    //                        throw;
    //                    }
    //                    finally
    //                    {
    //                        //     _sessionMutex.ReleaseMutex();
    //                    }
    //                }
    //            }finally
    //            {
    //                _sessionMutex.ReleaseMutex();
    //            }
    //            return sessionFactory;
    //        }
    //    }

    //    private static ValidatorEngine _validator;
    //    public static ValidatorEngine Validator
    //    {
    //        get
    //        {
    //            if (_validator == null)
    //            {
    //                _validator = new ValidatorEngine();
    //                var nhvConfig = InitializeValidationEngine();
    //                _validator.Configure(nhvConfig);
    //            }
    //            return _validator;
    //        }
    //    }
    //    private static Mutex _NHsessionMutex = new Mutex();
    //    public static ISession NhSession
    //    {
    //        get
    //        {
                
    //            ISession nhs;
    //            if (_sessionDistionry==null)
    //            {
    //                _sessionDistionry=new Dictionary<int, ISession>();
    //            }

    //            if (_sessionDistionry.ContainsKey(Thread.CurrentThread.ManagedThreadId))
    //            {
    //                nhs = _sessionDistionry[Thread.CurrentThread.ManagedThreadId];
    //            }
    //            else
    //            {
    //                nhs = SessionFactory.OpenSession();
    //                _sessionDistionry.Add(Thread.CurrentThread.ManagedThreadId, nhs);
                    
    //            }

    //            //_NHsessionMutex.WaitOne();
    //            //try
    //            //{
    //            //    if (_nhSession != null && _nhSession.IsOpen)
    //            //        nhs=_nhSession;
    //            //    else
    //            //    {
    //            //        _nhSession = SessionFactory.OpenSession();
    //            //        nhs= _nhSession;
    //            //    }
    //            //}finally
    //            //{
    //            //    _NHsessionMutex.ReleaseMutex();
    //            //}
    //            return nhs;
    //        }
    //    }
    //    public static ISession PrivateNhSession
    //    {
    //        get
    //        {


    //            var a = CreateSessionFactory();
    //            return a.OpenSession();

    //        }
    //    }

    //    //private static ISession _nhSession;
    //    //private static ISessionFactory _sessionFactory;
    //    public static void CreateDatabase()
    //    {
    //        ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
    //        Fluently.Configure()
    //            .Database(MsSqlConfiguration
    //                          .MsSql2008
    //                          .ConnectionString(ConnectionString))
    //            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
    //            .ExposeConfiguration(CreateSchema)
    //            .BuildConfiguration();
    //    }

    //    private static NHibernate.Validator.Cfg.Loquacious.FluentConfiguration InitializeValidationEngine()
    //    {
    //        var nhvConfig =
    //            new NHibernate.Validator.Cfg.Loquacious.FluentConfiguration();
    //        nhvConfig
    //            .SetDefaultValidatorMode(ValidatorMode.UseAttribute)
    //            .Register(typeof(DataAccess).Assembly.ValidationDefinitions())
    //            .IntegrateWithNHibernate
    //            .AvoidingDDLConstraints()
    //            .And
    //            .RegisteringListeners();

    //        return nhvConfig;
    //    }

    //    private static void CreateSchema(Configuration cfg)
    //    {
    //        var schemaExport = new SchemaExport(cfg);
    //        schemaExport.Drop(false, true);
    //        schemaExport.Create(false, true);
    //    }

    //    public static void UpdateDatabase()
    //    {
    //        ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
    //        CreateSessionFactory();
    //        Fluently.Configure()
    //            .Database(MsSqlConfiguration
    //                          .MsSql2008
    //                          .ConnectionString(ConnectionString))
    //            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
    //            .ExposeConfiguration(UpdateSchema)
    //            .BuildConfiguration();
    //    }

    //    private static void UpdateSchema(Configuration cfg)
    //    {
    //        var schemaUpdate = new SchemaUpdate(cfg);
    //        schemaUpdate.Execute(false, true);

    //    }

    //    private static Dictionary<int, ISession> _sessionDistionry;
    //    private static Dictionary<int, ISessionFactory> _sessionFactoryDistionry;

    //    private static ISessionFactory CreateSessionFactory()
    //    {
    //        ISessionFactory sf = null;
    //        _sessionFactoryMutex.WaitOne();
    //        try
    //        {

            
    //        if (_sessionFactoryDistionry==null)
    //        {
    //            _sessionFactoryDistionry=new Dictionary<int, ISessionFactory>();

    //        }
    //        if (_sessionFactoryDistionry.ContainsKey(Thread.CurrentThread.ManagedThreadId))
    //        {
    //            sf = _sessionFactoryDistionry[Thread.CurrentThread.ManagedThreadId];
    //        }
    //        else
    //        {
    //            ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
    //            var config = Fluently.Configure()
    //                .Database(MsSqlConfiguration
    //                              .MsSql2008
    //                              .ConnectionString(ConnectionString))
    //                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
    //                .ExposeConfiguration(UpdateSchema)
    //                .BuildConfiguration();
    //            config.Initialize(Validator);

    //            sf = config.BuildSessionFactory();
                
    //            _sessionFactoryDistionry.Add(Thread.CurrentThread.ManagedThreadId,sf);
    //        }


    //        //_sessionMutex.WaitOne();
    //        //try
    //        //{

    //        //    ConnectionString = ConfigurationManager.ConnectionStrings["SWSPDB"].ConnectionString;
    //        //    var config = Fluently.Configure()
    //        //        .Database(MsSqlConfiguration
    //        //                      .MsSql2008
    //        //                      .ConnectionString(ConnectionString))
    //        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataAccess>())
    //        //        .ExposeConfiguration(UpdateSchema)
    //        //        .BuildConfiguration();
    //        //    config.Initialize(Validator);

    //        //    sf = config.BuildSessionFactory();

    //        }
    //        catch (Exception)
    //        {
    //            throw;
    //        }
    //        finally
    //        {
    //            _sessionFactoryMutex.ReleaseMutex();

    //        }
    //        return sf;
    //    }

    //    public static void Flush()
    //    {
            

    //        _sessionDistionry[Thread.CurrentThread.ManagedThreadId].Close();
    //        //NhSession.Close();
    //    }
    //}

}
