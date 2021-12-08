using System;
using Autofac;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyJetWallet.DynamicLinkGenerator.Services;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;
using MyNoSqlServer.DataWriter;

namespace MyJetWallet.DynamicLinkGenerator.Ioc
{
    public static class AutofacHelper
    {
        public static void RegisterDynamicLinkClient(this ContainerBuilder builder, IMyNoSqlSubscriber myNoSqlClient)
        {
            builder
                .RegisterInstance(new MyNoSqlReadRepository<DynamicLinkSettingsNoSql>(myNoSqlClient, DynamicLinkSettingsNoSql.TableName))
                .As<IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql>>()
                .SingleInstance();

            builder
                .RegisterType<DynamicLinkClient>()
                .As<IDynamicLinkClient>()
                .SingleInstance();
        }

        public static void RegisterDynamicLinkSettingsWriter(this ContainerBuilder builder, Func<string> myNoSqlWriterUrl)
        {
            builder
                .RegisterInstance(new MyNoSqlServerDataWriter<DynamicLinkSettingsNoSql>(myNoSqlWriterUrl, DynamicLinkSettingsNoSql.TableName, true))
                .As<IMyNoSqlServerDataWriter<DynamicLinkSettingsNoSql>>()
                .SingleInstance();
            
        }
    }
}