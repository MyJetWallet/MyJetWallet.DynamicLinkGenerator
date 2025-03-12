namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class VerifyTransferLinkRequest: BaseLinkRequest
    {
    
        public string OperationId { get; set; }
        public string Code { get; set; }
    }
}