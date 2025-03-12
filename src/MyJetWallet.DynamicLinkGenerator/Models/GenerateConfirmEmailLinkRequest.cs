namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class ConfirmEmailLinkRequest : BaseLinkRequest
    {
    
        public string Code { get; set; }
        public string Token { get; set; }
    }
}