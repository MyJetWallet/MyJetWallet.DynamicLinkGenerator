namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateDepositSuccessLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public string OperationId { get; set; }
    }
}