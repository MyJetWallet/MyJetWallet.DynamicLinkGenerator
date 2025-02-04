using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public interface IDynamicLinkClient
{
    public (string longLink, string shortLink) GenerateLoginLink(LoginLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmEmailLink(ConfirmEmailLinkRequest request);
    public (string longLink, string shortLink) GenerateForgotPasswordLink(ForgotPasswordLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(WithdrawalLinkRequest request);
    public (string longLink, string shortLink) GenerateConfirmedTransferLink(TransferLinkRequest request);
    public (string longLink, string shortLink) GenerateInviteFriendLink(InviteFriendLinkRequest request);
    public (string longLink, string shortLink) GenerateKycVerificationLink(KycVerificationLinkRequest request);
    public (string longLink, string shortLink) GenerateDepositStartLink(DepositStartLinkRequest request);
    public (string longLink, string shortLink) GenerateTradingStartLink(TradingStartLinkRequest request);
    public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(VerifyWithdrawalLinkRequest request);
    public (string longLink, string shortLink) GenerateVerifyTransferLink(VerifyTransferLinkRequest request);
    public (string longLink, string shortLink) GenerateEarnLandingLink(EarnLandingLinkRequest request);
    public (string longLink, string shortLink) GenerateKycSuccessLink(KycSuccessLinkRequest request);
    public (string longLink, string shortLink) GenerateKycFailLink(KycFailLinkRequest request);
    public (string longLink, string shortLink) GenerateRecurringBuyLink(RecurringBuyLinkRequest request);
    public (string longLink, string shortLink) GenerateProfileDeleteLink(DeleteProfileLinkRequest request);
    public (string longLink, string shortLink) GenerateHighYieldLink(HighYieldLinkRequest request);
    public (string longLink, string shortLink) GenerateSupportLink(SupportLinkRequest request);
    public (string longLink, string shortLink) GenerateDepositSuccessLink(DepositSuccessLinkRequest request);
    public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(KycDocsDeclinedLinkRequest request);
    public (string longLink, string shortLink) GenerateKycDocumentsApprovedLink(KycDocsApprovedLinkRequest request);
    public (string longLink, string shortLink) GenerateKycBannedLink(KycBannedLinkRequest request);
    public (string longLink, string shortLink) GenerateOperationHistoryLink(OperationHistoryLinkRequest request);
    public (string longLink, string shortLink) GenerateWithdrawalDeclinedLink(WithdrawalDeclinedLinkRequest request);
    public (string longLink, string shortLink) GenerateGiftIncomingLink(OperationLinkRequest request);
    public (string longLink, string shortLink) GenerateGiftReminderLink(OperationLinkRequest request);
    public (string longLink, string shortLink) GenerateGiftCancelledLink(OperationLinkRequest request);
    public (string longLink, string shortLink) GenerateGiftExpiredLink(OperationLinkRequest request);
    public (string longLink, string shortLink) GenerateJarLink(JarLinkRequest request);
    public (string longLink, string shortLink) GenerateUnfinishedOpLink(UnfinishedOpRequest request);
    public (string longLink, string shortLink) GenerateP2PMethodAvailableLink(P2PMethodAvailableLinkRequest linkRequest);
    public (string longLink, string shortLink) GenerateCardHistoryLink(CardHistoryLinkRequest request);

}