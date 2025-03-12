namespace MyJetWallet.DynamicLinkGenerator.Models;

public class P2PMethodAvailableLinkRequest: BaseLinkRequest
{

    public string MethodName { get; set; }
    public string TypeOperation { get; set; }
    public string Country { get; set; }
}