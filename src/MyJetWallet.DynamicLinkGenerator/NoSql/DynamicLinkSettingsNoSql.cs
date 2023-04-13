using System.Collections.Generic;
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
    public string BaseLink { get; set; }

    public static DynamicLinkSettingsNoSql GenerateCreate(string brand, string domainUriPrefix,string androidPackageName, string iosBundleId, string baseLink )
    {
        return new DynamicLinkSettingsNoSql()
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(brand),
            DomainUriPrefix = domainUriPrefix,
            BaseLink = baseLink,
            AndroidPackageName = androidPackageName,
            IosBundleId = iosBundleId
        };
    }
}