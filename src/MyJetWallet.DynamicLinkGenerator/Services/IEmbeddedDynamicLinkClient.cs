using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IEmbeddedDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateEmbeddedOperationHistoryLink(string accountId, string historyId);
}