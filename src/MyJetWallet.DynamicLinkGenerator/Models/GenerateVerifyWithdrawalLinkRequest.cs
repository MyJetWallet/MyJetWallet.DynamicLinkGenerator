namespace MyJetWallet.DynamicLinkGenerator.Models
{
    public class VerifyWithdrawalLinkRequest: BaseLinkRequest
    {
    
        public string OperationId { get; set; }
        public string Code { get; set; }
    }
}