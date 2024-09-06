using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataWriter;

namespace TestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var paramsArray = new List<(string, string)>() {("jw_operation_id", "test")};
            var action = ActionEnum.OperationHistory;
            var deepLink = $"action/{action.GetString()}";
            foreach (var (name, value) in paramsArray) 
                deepLink = $"{deepLink}/{name}/{value}";
            
            var parameters = new DynamicLinkSettingsNoSql()
            {
                BaseLink = "https://promo.simple.app/1Qd2",
                AfXp = "custom",
                Pid = "test",
                C = "test"
            };
            
            var link = $"{parameters.BaseLink}?af_xp={parameters.AfXp}&pid={parameters.Pid}&c={parameters.C}&deep_link_value={deepLink}";
            
            Console.WriteLine(link);
        }

    }
}