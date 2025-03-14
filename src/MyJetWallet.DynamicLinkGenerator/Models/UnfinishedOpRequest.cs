namespace MyJetWallet.DynamicLinkGenerator.Models;

public class UnfinishedOpRequest: BaseLinkRequest
{

    public string FromAsset { get; set; }
    public string ToAsset { get; set; }
    public string FromAmount { get; set; }
    public string ToAmount { get; set; }
    public string Amount { get; set; }
    public string Side { get; set; }
    public string Operation { get; set; }
    public string CardId { get; set; }
    public string ReceiveMethodId { get; set; }
    public string AccountId { get; set; }
    public string ToIban { get; set; }
    public string IbanBankCode { get; set; }
    public bool? IsFromFixed { get; set; }
}