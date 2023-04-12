using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateLoginLink(GenerateLoginLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmEmailLink(GenerateConfirmEmailLinkRequest request);
    public (string longLink, string shortLink) GenerateForgotPasswordLink(GenerateForgotPasswordLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(GenerateWithdrawalLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmedTransferLink(GenerateTransferLinkRequest request);
    public (string longLink, string shortLink) GenerateInviteFriendLink(GenerateInviteFriendLinkRequest request);
    public (string longLink, string shortLink) GenerateKycVerificationLink(GenerateKycVerificationLinkRequest request);
    public (string longLink, string shortLink) GenerateDepositStartLink(GenerateDepositStartLinkRequest request);
    public (string longLink, string shortLink) GenerateTradingStartLink(GenerateTradingStartLinkRequest request);
    public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(GenerateVerifyWithdrawalLinkRequest request);
    public (string longLink, string shortLink) GenerateVerifyTransferLink(GenerateVerifyTransferLinkRequest request);
    public (string longLink, string shortLink) GenerateEarnLandingLink(GenerateEarnLandingLinkRequest request);
    public (string longLink, string shortLink) GenerateKycSuccessLink(GenerateKycSuccessLinkRequest request);
    public (string longLink, string shortLink) GenerateKycFailLink(GenerateKycFailLinkRequest request);
    public (string longLink, string shortLink) GenerateRecurringBuyLink(GenerateRecurringBuyLinkRequest request);
    public (string longLink, string shortLink) GenerateProfileDeleteLink(GenerateDeleteProfileLinkRequest request);
    public (string longLink, string shortLink) GenerateHighYieldLink(GenerateHighYieldLinkRequest request);
    public (string longLink, string shortLink) GenerateSupportLink(GenerateSupportLinkRequest request);
    public (string longLink, string shortLink) GenerateDepositSuccessLink(GenerateDepositSuccessLinkRequest request);
    public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(GenerateKycDocsDeclinedLinkRequest request);
}
    