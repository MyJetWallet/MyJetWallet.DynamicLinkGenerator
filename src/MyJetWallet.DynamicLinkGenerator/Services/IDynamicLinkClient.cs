using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateLoginLink(GenerateLoginLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmEmailLink(GenerateConfirmEmailLinkRequest request);
    public (string longLink, string shortLink) GenerateForgotPasswordLink(GenerateForgotPasswordLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmWithdrawalLink(GenerateWithdrawalLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmTransferLink(GenerateTransferLinkRequest request);
    public (string longLink, string shortLink) GenerateInviteFriendLink(GenerateInviteFriendLinkRequest request);
    public (string longLink, string shortLink) GenerateKycVerificationLink(GenerateKycVerificationLinkRequest request);
    public (string longLink, string shortLink) GenerateDepositStartLink(GenerateDepositStartLinkRequest request);
    public (string longLink, string shortLink) GenerateTradingStartLink(GenerateTradingStartLinkRequest request);
}
    