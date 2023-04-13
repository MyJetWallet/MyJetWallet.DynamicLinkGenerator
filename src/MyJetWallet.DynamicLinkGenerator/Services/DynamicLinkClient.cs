using System;
using System.Linq;
using System.Web;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.Services
{
    public class DynamicLinkClient : IDynamicLinkClient
    {
        private readonly IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> _reader;

        public DynamicLinkClient(IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> reader)
        {
            _reader = reader;
        }
        
        public (string longLink, string shortLink) GenerateLoginLink(LoginLinkRequest request) => GenerateDeepLink(ActionEnum.Login, request.Brand, ("jw_email", request.Email));
        public (string longLink, string shortLink) GenerateConfirmEmailLink(ConfirmEmailLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmEmail, request.Brand, ("jw_code", request.Code), ("jw_token", request.Token));
        public (string longLink, string shortLink) GenerateForgotPasswordLink(ForgotPasswordLinkRequest request) => GenerateDeepLink(ActionEnum.ForgotPassword, request.Brand, ("jw_token", request.Token), ("jw_code", request.Code));
        public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(WithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmWithdrawal, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateConfirmedTransferLink(TransferLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmTransfer, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateInviteFriendLink(InviteFriendLinkRequest request) => GenerateDeepLink(ActionEnum.InviteFriend, request.Brand);
        public (string longLink, string shortLink) GenerateKycVerificationLink(KycVerificationLinkRequest request) => GenerateDeepLink(ActionEnum.KycVerification, request.Brand);
        public (string longLink, string shortLink) GenerateDepositStartLink(DepositStartLinkRequest request) => GenerateDeepLink(ActionEnum.DepositStart, request.Brand);
        public (string longLink, string shortLink) GenerateTradingStartLink(TradingStartLinkRequest request) => GenerateDeepLink(ActionEnum.TradingStart, request.Brand);
        public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(VerifyWithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyWithdrawal, request.Brand, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        public (string longLink, string shortLink) GenerateVerifyTransferLink(VerifyTransferLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyTransfer, request.Brand, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        public (string longLink, string shortLink) GenerateEarnLandingLink(EarnLandingLinkRequest request) => GenerateDeepLink(ActionEnum.EarnLanding, request.Brand);
        public (string longLink, string shortLink) GenerateKycSuccessLink(KycSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.KycSuccess, request.Brand);
        public (string longLink, string shortLink) GenerateKycFailLink(KycFailLinkRequest request) => GenerateDeepLink(ActionEnum.KycFail, request.Brand);
        public (string longLink, string shortLink) GenerateRecurringBuyLink(RecurringBuyLinkRequest request) => GenerateDeepLink(ActionEnum.RecurringBuyStart, request.Brand);
        public (string longLink, string shortLink) GenerateProfileDeleteLink(DeleteProfileLinkRequest request) => GenerateDeepLink(ActionEnum.ProfileDelete, request.Brand, ("jw_code", request.Code));
        public (string longLink, string shortLink) GenerateHighYieldLink(HighYieldLinkRequest request) => GenerateDeepLink(ActionEnum.HighYield, request.Brand);
        public (string longLink, string shortLink) GenerateSupportLink(SupportLinkRequest request) => GenerateDeepLink(ActionEnum.SupportPage, request.Brand);
        public (string longLink, string shortLink) GenerateDepositSuccessLink(DepositSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.DepositSuccess, request.Brand);
        public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(KycDocsDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsDeclined, request.Brand);
        public (string longLink, string shortLink) GenerateKycDocumentsApprovedLink(KycDocsApprovedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsApproved, request.Brand);
        public (string longLink, string shortLink) GenerateKycBannedLink(KycBannedLinkRequest request) => GenerateDeepLink(ActionEnum.KycBanned, request.Brand);
        public (string longLink, string shortLink) GenerateOperationHistoryLink(OperationHistoryLinkRequest request) => GenerateDeepLink(ActionEnum.OperationHistory, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateWithdrawalDeclinedLink(WithdrawalDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.WithdrawalDecline, request.Brand, ("jw_asset", request.Asset));

        private (string longLink, string shortLink) GenerateDeepLink(ActionEnum action, string brand, params(string, string)[] paramsArray)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(brand));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for brand {brand}");
            
            var deepLink = $"{parameters.BaseLink}/action/{action.GetString()}";
            foreach (var (name, value) in paramsArray) 
                deepLink = $"{deepLink}/{name}/{value}";
            
            return ($"{parameters.DomainUriPrefix}/?link={HttpUtility.UrlEncode(deepLink)}&apn={parameters.AndroidPackageName}&ibi={parameters.IosBundleId}&isi={parameters.IosStoreId}&efr=1", deepLink);
        }
    }
}