namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class ConfirmEmailLinkRequest
    {
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Token { get; set; }
    }
}