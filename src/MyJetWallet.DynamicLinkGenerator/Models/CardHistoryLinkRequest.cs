using MyJetWallet.Domain;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public class CardHistoryLinkRequest : BaseLinkRequest
{
    public string CardId { get; set; }
    public string OperationId { get; set; }
}