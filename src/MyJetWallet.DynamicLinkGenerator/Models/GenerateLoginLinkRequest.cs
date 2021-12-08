namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateLoginLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
    }
}