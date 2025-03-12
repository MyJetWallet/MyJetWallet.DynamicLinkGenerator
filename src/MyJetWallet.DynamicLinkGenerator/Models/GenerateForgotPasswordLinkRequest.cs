namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class ForgotPasswordLinkRequest: BaseLinkRequest
    {
    
        public string Token { get; set; }
        public string Code { get; set; }
    }
}