namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class VerifyTransferLinkRequest
    {
        public string Brand { get; set; }
        public string OperationId { get; set; }
        public string Code { get; set; }
    }
}