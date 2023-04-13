namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class ForgotPasswordLinkRequest
    {
        public string Brand { get; set; }
        public string Token { get; set; }
        public string Code { get; set; }
    }
}