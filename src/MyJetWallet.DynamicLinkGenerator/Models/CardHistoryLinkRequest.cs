namespace MyJetWallet.DynamicLinkGenerator.Models;

public class CardHistoryLinkRequest
{
    public string Brand { get; set; }
    public string CardId { get; set; }
    public string OperationId { get; set; }
}