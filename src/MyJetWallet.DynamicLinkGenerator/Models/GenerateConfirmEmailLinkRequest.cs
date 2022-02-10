namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateConfirmEmailLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public string Code { get; set; }
        public string Token { get; set; }
    }
}