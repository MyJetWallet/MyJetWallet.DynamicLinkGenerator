using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IEmbeddedDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateEmbeddedOperationHistoryLink(string accountId, string historyId);
    public (string longLink, string shortLink) GenerateEmbeddedDiscoveryLink(DiscoveryTabActionEnum tab);
}

public enum DiscoveryTabActionEnum
{
    Events=0,
    Academy=1,
    News=3
}