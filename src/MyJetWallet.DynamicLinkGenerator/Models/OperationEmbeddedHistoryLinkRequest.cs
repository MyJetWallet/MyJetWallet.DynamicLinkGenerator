namespace MyJetWallet.DynamicLinkGenerator.Models;

public class OperationEmbeddedHistoryLinkRequest: BaseLinkRequest
{
    public string OperationId { get; set; }
    public string AccountId { get; set; }
}