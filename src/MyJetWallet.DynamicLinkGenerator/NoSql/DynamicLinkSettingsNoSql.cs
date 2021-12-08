using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.NoSql;

public class DynamicLinkSettingsNoSql : MyNoSqlDbEntity
{
    public const string TableName = "myjetwallet-dynlink-settings";
    public static string GeneratePartitionKey()
    {
        return "DynLinkSettings";
    }

    public static string GenerateRowKey(string brand)
    {
        return brand;
    }

    public string DomainUriPrefix { get; set; }
        
    public string LinkBaseUrlDefault { get; set; }
        
    public string LinkBaseUrlIos { get; set; }
        
    public string LinkBaseUrlAndroid { get; set; }
        
    public string AndroidPackageName { get; set; }       
        
    public string IosBundleId { get; set; }
    
            
    public static DynamicLinkSettingsNoSql Create(string brand, string domainUriPrefix, string linkBaseUrlDefault, string linkBaseUrlIos, string linkBaseUrlAndroid, string androidPackageName, string iosBundleId )
    {
        return new DynamicLinkSettingsNoSql()
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(brand),
            DomainUriPrefix = domainUriPrefix,
            LinkBaseUrlAndroid = linkBaseUrlAndroid,
            LinkBaseUrlDefault = linkBaseUrlDefault,
            LinkBaseUrlIos = linkBaseUrlIos,
            AndroidPackageName = androidPackageName,
            IosBundleId = iosBundleId
        };
    }
}