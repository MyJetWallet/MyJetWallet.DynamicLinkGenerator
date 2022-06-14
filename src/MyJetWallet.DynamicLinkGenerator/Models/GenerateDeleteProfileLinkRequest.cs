namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateDeleteProfileLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public string Code { get; set; }
    }
}