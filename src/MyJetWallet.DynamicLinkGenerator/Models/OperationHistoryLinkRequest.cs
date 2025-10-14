namespace MyJetWallet.DynamicLinkGenerator.Models;

public class OperationHistoryLinkRequest: BaseLinkRequest
{
    public string OperationId { get; set; }
    
    public string OriginalOperationId { get; set; }
}