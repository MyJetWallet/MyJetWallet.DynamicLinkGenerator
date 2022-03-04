namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateVerifyWithdrawalLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public string OperationId { get; set; }
        public string Code { get; set; }
    }
}