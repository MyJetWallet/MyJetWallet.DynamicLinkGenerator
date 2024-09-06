using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.NoSql;

public class DynamicLinkSettingsNoSql : MyNoSqlDbEntity
{
    public const string TableName = "myjetwallet-dynlink-settings-v2";
    public static string GeneratePartitionKey() => "DynLinkSettings";
    public static string GenerateRowKey(string brand) => brand;
    
    [Obsolete] public string DomainUriPrefix { get; set; }
    [Obsolete] public string AndroidPackageName { get; set; }
    [Obsolete] public string IosBundleId { get; set; }
    [Obsolete] public string IosStoreId { get; set; }
    public string BaseLink { get; set; }
    public string Pid { get; set; }
    public string C { get; set; }
    public string AfXp { get; set; }

    public static DynamicLinkSettingsNoSql GenerateCreate(string brand, string baseLink, string pid, string c, string afXp)
    {
        return new DynamicLinkSettingsNoSql()
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(brand),
            BaseLink = baseLink,
            Pid = pid,
            C = c,
            AfXp = afXp,
        };
    }
}