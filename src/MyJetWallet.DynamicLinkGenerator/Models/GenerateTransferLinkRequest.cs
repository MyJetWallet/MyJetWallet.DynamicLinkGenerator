namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class GenerateTransferLinkRequest
    {
        public string Brand { get; set; }
        public DeviceTypeEnum DeviceType { get; set; }
        public string OperationId { get; set; }
        public string ErrorCode { get; set; }
        public string Token { get; set; }
    }
}