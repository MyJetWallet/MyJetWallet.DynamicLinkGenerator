namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateKycVerificationLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
    }
}