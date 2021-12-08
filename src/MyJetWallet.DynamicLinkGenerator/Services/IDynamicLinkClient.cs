using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IDynamicLinkClient
{
    public string GenerateLoginLink(GenerateLoginLinkRequest request);
    public string GenerateConfirmEmailLink(GenerateConfirmEmailLinkRequest request);
    public string GenerateForgotPasswordLink(GenerateForgotPasswordLinkRequest request);
    public string GenerateConfirmWithdrawalLink(GenerateWithdrawalLinkRequest request);
    public string GenerateConfirmTransferLink(GenerateTransferLinkRequest request);
    public string GenerateInviteFriendLink(GenerateInviteFriendLinkRequest request);
}