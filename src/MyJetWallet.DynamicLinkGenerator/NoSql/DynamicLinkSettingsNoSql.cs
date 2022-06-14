using System.Collections.Generic;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.NoSql;

public class DynamicLinkSettingsNoSql : MyNoSqlDbEntity
{
    public const string TableName = "myjetwallet-dynlink-settings-v2";
    public static string GeneratePartitionKey() => "DynLinkSettings";
    public static string GenerateRowKey(string brand) => brand;
    public string DomainUriPrefix { get; set; }
    public string AndroidPackageName { get; set; }
    public string IosBundleId { get; set; }
    public string IosStoreId { get; set; }

    public Dictionary<ActionEnum, BaseLinks> LinksMap { get; set; }

    public static DynamicLinkSettingsNoSql Create(string brand, string domainUriPrefix,string androidPackageName, string iosBundleId, Dictionary<ActionEnum, BaseLinks> linksMap )
    {
        return new DynamicLinkSettingsNoSql()
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(brand),
            DomainUriPrefix = domainUriPrefix,
            LinksMap = linksMap,
            AndroidPackageName = androidPackageName,
            IosBundleId = iosBundleId
        };
    }
    
    public class BaseLinks
    {
        public string BaseLinkDefault { get; set; }
        public string BaseLinkIos { get; set; }
        public string BaseLinkAndroid { get; set; }
    }
}