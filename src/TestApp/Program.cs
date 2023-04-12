using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.DataWriter;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var writer = new MyNoSqlServerDataWriter<DynamicLinkSettingsNoSql>(() => "http://192.168.70.80:5123",
                DynamicLinkSettingsNoSql.TableName, false);

            var t = await writer.GetAsync();
            
        }

    }
}