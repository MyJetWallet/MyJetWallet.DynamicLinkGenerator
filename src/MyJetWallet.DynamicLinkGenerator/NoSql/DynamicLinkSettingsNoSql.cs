using System;
using System.Collections.Generic;
using MyJetWallet.Domain;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.NoSql;

public class DynamicLinkSettingsNoSql : MyNoSqlDbEntity
{
    public const string TableName = "myjetwallet-dynlink-settings-v2";
    public static string GeneratePartitionKey() => "DynLinkSettings";
    public static string GenerateRowKey(PlatformType platformType) => platformType.ToString().ToLower();
    public string DomainUriPrefix { get; set; }
    public string BaseLink { get; set; }
    public string Pid { get; set; }
    public string C { get; set; }
    public string AfXp { get; set; }

    public static DynamicLinkSettingsNoSql GenerateCreate(PlatformType platformType, string baseLink, string pid, string c, string afXp, string domainUriPrefix){
        return new DynamicLinkSettingsNoSql()
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(platformType),
            BaseLink = baseLink,
            Pid = pid,
            C = c,
            AfXp = afXp,
            DomainUriPrefix = domainUriPrefix
        };
    }
}