using System;
using System.Collections.Generic;
using System.Web;
using MyJetWallet.Domain;
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
        
        public (string longLink, string shortLink) GenerateLoginLink(LoginLinkRequest request) => GenerateDeepLink(ActionEnum.Login, request.Platform, ("jw_email", request.Email));
        public (string longLink, string shortLink) GenerateConfirmEmailLink(ConfirmEmailLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmEmail, request.Platform, ("jw_code", request.Code), ("jw_token", request.Token));
        public (string longLink, string shortLink) GenerateConfirmEmailLinkNonCustodial(ConfirmEmailLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmEmailNonCustodial, request.Platform, ("jw_code", request.Code), ("jw_token", request.Token));
        [Obsolete] public (string longLink, string shortLink) GenerateForgotPasswordLink(ForgotPasswordLinkRequest request) => GenerateDeepLink(ActionEnum.ForgotPassword, request.Platform, ("jw_token", request.Token), ("jw_code", request.Code));
        [Obsolete] public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(WithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmWithdrawal, request.Platform, ("jw_operation_id", request.OperationId));
        [Obsolete] public (string longLink, string shortLink) GenerateConfirmedTransferLink(TransferLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmTransfer, request.Platform, ("jw_operation_id", request.OperationId));
        [Obsolete] public (string longLink, string shortLink) GenerateInviteFriendLink(InviteFriendLinkRequest request) => GenerateDeepLink(ActionEnum.InviteFriend, request.Platform);
        [Obsolete] public (string longLink, string shortLink) GenerateKycVerificationLink(KycVerificationLinkRequest request) => GenerateDeepLink(ActionEnum.KycVerification, request.Platform);
        [Obsolete] public (string longLink, string shortLink) GenerateDepositStartLink(DepositStartLinkRequest request) => GenerateDeepLink(ActionEnum.DepositStart, request.Platform);
        [Obsolete] public (string longLink, string shortLink) GenerateTradingStartLink(TradingStartLinkRequest request) => GenerateDeepLink(ActionEnum.TradingStart, request.Platform);
        [Obsolete]public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(VerifyWithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyWithdrawal, request.Platform, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        [Obsolete]public (string longLink, string shortLink) GenerateVerifyTransferLink(VerifyTransferLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyTransfer, request.Platform, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        [Obsolete]public (string longLink, string shortLink) GenerateEarnLandingLink(EarnLandingLinkRequest request) => GenerateDeepLink(ActionEnum.EarnLanding, request.Platform);
        [Obsolete]public (string longLink, string shortLink) GenerateKycSuccessLink(KycSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.KycSuccess, request.Platform);
        [Obsolete]public (string longLink, string shortLink) GenerateKycFailLink(KycFailLinkRequest request) => GenerateDeepLink(ActionEnum.KycFail, request.Platform);
        [Obsolete]public (string longLink, string shortLink) GenerateRecurringBuyLink(RecurringBuyLinkRequest request) => GenerateDeepLink(ActionEnum.RecurringBuyStart, request.Platform);
        [Obsolete]public (string longLink, string shortLink) GenerateProfileDeleteLink(DeleteProfileLinkRequest request) => GenerateDeepLink(ActionEnum.ProfileDelete, request.Platform, ("jw_code", request.Code));
        [Obsolete] public (string longLink, string shortLink) GenerateHighYieldLink(HighYieldLinkRequest request) => GenerateDeepLink(ActionEnum.HighYield, request.Platform);
        public (string longLink, string shortLink) GenerateSupportLink(SupportLinkRequest request) => GenerateDeepLink(ActionEnum.SupportPage, request.Platform);
        public (string longLink, string shortLink) GenerateDepositSuccessLink(DepositSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.DepositSuccess, request.Platform, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(KycDocsDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsDeclined, request.Platform);
        public (string longLink, string shortLink) GenerateKycDocumentsApprovedLink(KycDocsApprovedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsApproved, request.Platform);
        public (string longLink, string shortLink) GenerateKycBannedLink(KycBannedLinkRequest request) => GenerateDeepLink(ActionEnum.KycBanned, request.Platform);
        public (string longLink, string shortLink) GenerateOperationHistoryLink(OperationHistoryLinkRequest request)
        {
            var paramsLinks = new List<(string, string)>() {("jw_operation_id", request.OperationId)};
            if (!string.IsNullOrEmpty(request.AccountId))
            {
                paramsLinks.Add(("jw_accountID", request.AccountId));
            }
            return GenerateDeepLink(ActionEnum.OperationHistory, request.Platform,
                paramsArray: paramsLinks.ToArray());
        }

        public (string longLink, string shortLink) GenerateWithdrawalDeclinedLink(WithdrawalDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.WithdrawalDecline, request.Platform, ("jw_asset", request.Asset));
        public (string longLink, string shortLink) GenerateGiftIncomingLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftIncoming, request.Platform, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftReminderLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftReminder, request.Platform, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftCancelledLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftCancelled, request.Platform, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftExpiredLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftExpired, request.Platform, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateJarLink(JarLinkRequest request) => GenerateDeepLink(ActionEnum.Jar, request.Platform, ("jw_jar_id", request.JarId));
        public (string longLink, string shortLink) GenerateCardHistoryLink(CardHistoryLinkRequest request) => GenerateDeepLink(ActionEnum.CardHistory, request.Platform, ("crypto_card_id", request.CardId), ("jw_operation_id", request.OperationId));

        public (string longLink, string shortLink) GenerateUnfinishedOpLink(UnfinishedOpRequest request)
        {
            var parameters = new List<(string, string)>();
            AddParamIfNotEmpty("jw_fromAsset", request.FromAsset);
            AddParamIfNotEmpty("jw_toAsset", request.ToAsset);
            AddParamIfNotEmpty("jw_fromAmount", request.FromAmount);
            AddParamIfNotEmpty("jw_toAmount", request.ToAmount);
            AddParamIfNotEmpty("jw_amount", request.Amount);
            AddParamIfNotEmpty("jw_side", request.Side);
            AddParamIfNotEmpty("jw_operation ", request.Operation);
            AddParamIfNotEmpty("jw_cardId", request.CardId);
            AddParamIfNotEmpty("jw_receiveMethodId", request.ReceiveMethodId);
            AddParamIfNotEmpty("jw_accountID", request.AccountId);
            AddParamIfNotEmpty("jw_toIban", request.ToIban);
            AddParamIfNotEmpty("jw_ibanBankCode", request.IbanBankCode);
            if (request.IsFromFixed.HasValue)
            {
                AddParamIfNotEmpty("jw_isFromFixed", request.IsFromFixed.Value.ToString().ToLower());
            }

            return GenerateDeepLink(ActionEnum.UnfinishedOperation, request.Platform, paramsArray: parameters.ToArray());

            void AddParamIfNotEmpty(string key, string value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    parameters.Add((key,value));
                }
            }
        }

        public (string longLink, string shortLink) GenerateP2PMethodAvailableLink(P2PMethodAvailableLinkRequest linkRequest)
        {
            var parameters = new List<(string, string)>();
            AddParamIfNotEmpty("jw_method_name", linkRequest.MethodName);
            AddParamIfNotEmpty("jw_type_operation", linkRequest.TypeOperation);
            AddParamIfNotEmpty("jw_country", linkRequest.Country);

            return GenerateDeepLink(ActionEnum.P2PMethodAvailable, linkRequest.Platform, parameters.ToArray());

            void AddParamIfNotEmpty(string key, string value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    parameters.Add((key,value));
                }
            }
        }

        private (string longLink, string shortLink) GenerateDeepLink(ActionEnum action, PlatformType platform, params(string, string)[] paramsArray)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(platform));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for platform {platform}");
            
            var deepLink = $"{parameters.DomainUriPrefix}/action/{action.GetString()}";
            foreach (var (name, value) in paramsArray) 
                deepLink = $"{deepLink}/{name}/{value}";
            
            var link = $"{parameters.BaseLink}?af_xp={parameters.AfXp}&pid={parameters.Pid}&c={parameters.C}&deep_link_value={HttpUtility.UrlEncode(deepLink)}";
            return (link, deepLink);
        }
    }
}