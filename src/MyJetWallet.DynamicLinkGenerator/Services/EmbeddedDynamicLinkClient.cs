using System;
using System.Web;
using MyJetWallet.Domain;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public class EmbeddedDynamicLinkClient : IEmbeddedDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateEmbeddedOperationHistoryLink(string accountId, string historyId) 
        => GenerateDeepLink(ActionEmbeddedEnum.EmbeddedOperationHistory, ("jw_account_id", accountId), ("jw_history_id", historyId));
        
        
    #region technical methods
    private readonly IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> _reader;

    public EmbeddedDynamicLinkClient(IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> reader)
    {
        _reader = reader;
    }
        
    private (string longLink, string shortLink) GenerateDeepLink(ActionEmbeddedEnum action, params(string, string)[] paramsArray)
    {
        var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
            DynamicLinkSettingsNoSql.GenerateRowKey(PlatformType.Embedded));
            
        if (parameters == null)
            throw new ArgumentException($"Unable to get link parameters for platform {PlatformType.Embedded}");
            
        var deepLink = $"{parameters.DomainUriPrefix}/action/{action.GetString()}";
        foreach (var (name, value) in paramsArray) 
            deepLink = $"{deepLink}/{name}/{value}";
            
        var link = $"{parameters.BaseLink}?af_xp={parameters.AfXp}&pid={parameters.Pid}&c={parameters.C}&deep_link_value={HttpUtility.UrlEncode(deepLink)}";
        return (link, deepLink);
    }
    #endregion
}