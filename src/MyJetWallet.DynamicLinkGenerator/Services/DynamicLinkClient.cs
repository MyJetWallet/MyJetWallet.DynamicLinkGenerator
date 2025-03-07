using System;
using System.Collections.Generic;
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
        [Obsolete] public (string longLink, string shortLink) GenerateForgotPasswordLink(ForgotPasswordLinkRequest request) => GenerateDeepLink(ActionEnum.ForgotPassword, request.Brand, ("jw_token", request.Token), ("jw_code", request.Code));
        [Obsolete] public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(WithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmWithdrawal, request.Brand, ("jw_operation_id", request.OperationId));
        [Obsolete] public (string longLink, string shortLink) GenerateConfirmedTransferLink(TransferLinkRequest request) => GenerateDeepLink(ActionEnum.ConfirmTransfer, request.Brand, ("jw_operation_id", request.OperationId));
        [Obsolete] public (string longLink, string shortLink) GenerateInviteFriendLink(InviteFriendLinkRequest request) => GenerateDeepLink(ActionEnum.InviteFriend, request.Brand);
        [Obsolete] public (string longLink, string shortLink) GenerateKycVerificationLink(KycVerificationLinkRequest request) => GenerateDeepLink(ActionEnum.KycVerification, request.Brand);
        [Obsolete] public (string longLink, string shortLink) GenerateDepositStartLink(DepositStartLinkRequest request) => GenerateDeepLink(ActionEnum.DepositStart, request.Brand);
        [Obsolete] public (string longLink, string shortLink) GenerateTradingStartLink(TradingStartLinkRequest request) => GenerateDeepLink(ActionEnum.TradingStart, request.Brand);
        [Obsolete]public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(VerifyWithdrawalLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyWithdrawal, request.Brand, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        [Obsolete]public (string longLink, string shortLink) GenerateVerifyTransferLink(VerifyTransferLinkRequest request) => GenerateDeepLink(ActionEnum.VerifyTransfer, request.Brand, ("jw_operation_id", request.OperationId), ("jw_code", request.Code));
        [Obsolete]public (string longLink, string shortLink) GenerateEarnLandingLink(EarnLandingLinkRequest request) => GenerateDeepLink(ActionEnum.EarnLanding, request.Brand);
        [Obsolete]public (string longLink, string shortLink) GenerateKycSuccessLink(KycSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.KycSuccess, request.Brand);
        [Obsolete]public (string longLink, string shortLink) GenerateKycFailLink(KycFailLinkRequest request) => GenerateDeepLink(ActionEnum.KycFail, request.Brand);
        [Obsolete]public (string longLink, string shortLink) GenerateRecurringBuyLink(RecurringBuyLinkRequest request) => GenerateDeepLink(ActionEnum.RecurringBuyStart, request.Brand);
        [Obsolete]public (string longLink, string shortLink) GenerateProfileDeleteLink(DeleteProfileLinkRequest request) => GenerateDeepLink(ActionEnum.ProfileDelete, request.Brand, ("jw_code", request.Code));
        [Obsolete] public (string longLink, string shortLink) GenerateHighYieldLink(HighYieldLinkRequest request) => GenerateDeepLink(ActionEnum.HighYield, request.Brand);
        public (string longLink, string shortLink) GenerateSupportLink(SupportLinkRequest request) => GenerateDeepLink(ActionEnum.SupportPage, request.Brand);
        public (string longLink, string shortLink) GenerateDepositSuccessLink(DepositSuccessLinkRequest request) => GenerateDeepLink(ActionEnum.DepositSuccess, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(KycDocsDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsDeclined, request.Brand);
        public (string longLink, string shortLink) GenerateKycDocumentsApprovedLink(KycDocsApprovedLinkRequest request) => GenerateDeepLink(ActionEnum.KycDocumentsApproved, request.Brand);
        public (string longLink, string shortLink) GenerateKycBannedLink(KycBannedLinkRequest request) => GenerateDeepLink(ActionEnum.KycBanned, request.Brand);
        public (string longLink, string shortLink) GenerateOperationHistoryLink(OperationHistoryLinkRequest request) => GenerateDeepLink(ActionEnum.OperationHistory, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateWithdrawalDeclinedLink(WithdrawalDeclinedLinkRequest request) => GenerateDeepLink(ActionEnum.WithdrawalDecline, request.Brand, ("jw_asset", request.Asset));
        public (string longLink, string shortLink) GenerateGiftIncomingLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftIncoming, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftReminderLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftReminder, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftCancelledLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftCancelled, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateGiftExpiredLink(OperationLinkRequest request) => GenerateDeepLink(ActionEnum.GiftExpired, request.Brand, ("jw_operation_id", request.OperationId));
        public (string longLink, string shortLink) GenerateJarLink(JarLinkRequest request) => GenerateDeepLink(ActionEnum.Jar, request.Brand, ("jw_jar_id", request.JarId));
        public (string longLink, string shortLink) GenerateCardHistoryLink(CardHistoryLinkRequest request) => GenerateDeepLink(ActionEnum.CardHistory, request.Brand, ("crypto_card_id", request.CardId), ("jw_operation_id", request.OperationId));

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

            return GenerateDeepLink(ActionEnum.UnfinishedOperation, request.Brand, paramsArray: parameters.ToArray());

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

            return GenerateDeepLink(ActionEnum.P2PMethodAvailable, linkRequest.Brand, parameters.ToArray());

            void AddParamIfNotEmpty(string key, string value)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    parameters.Add((key,value));
                }
            }
        }

        private (string longLink, string shortLink) GenerateDeepLink(ActionEnum action, string brand, params(string, string)[] paramsArray)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(brand));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for brand {brand}");
            
            var deepLink = $"{parameters.DomainUriPrefix}/action/{action.GetString()}";
            foreach (var (name, value) in paramsArray) 
                deepLink = $"{deepLink}/{name}/{value}";
            
            var link = $"{parameters.BaseLink}?af_xp={parameters.AfXp}&pid={parameters.Pid}&c={parameters.C}&deep_link_value={HttpUtility.UrlEncode(deepLink)}";
            return (link, deepLink);
        }
    }
}