using System;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.Abstractions;

namespace MyJetWallet.DynamicLinkGenerator.Services
{
    public class DynamicLinkClient : IDynamicLinkClient
    {
        private readonly IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> _reader;
        private readonly ILogger<DynamicLinkClient> _logger;

        public DynamicLinkClient(IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> reader, ILogger<DynamicLinkClient> logger)
        {
            _reader = reader;
            _logger = logger;
        }

        public (string longLink, string shortLink) GenerateLoginLink(GenerateLoginLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=Login&jw_email={request.Email}");
            return GenerateDeepLink(ActionEnum.Login, request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateConfirmEmailLink(GenerateConfirmEmailLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ConfirmEmail&jw_code={request.Code}&jw_token={request.Token}");
            return GenerateDeepLink(ActionEnum.ConfirmEmail, request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateForgotPasswordLink(GenerateForgotPasswordLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ForgotPassword&jw_token={request.Token}&jw_code={request.Code}");
            return GenerateDeepLink(ActionEnum.ForgotPassword, request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateConfirmedWithdrawalLink(GenerateWithdrawalLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_withdrawal_email_confirm&jw_operation_id={request.OperationId}");
            return GenerateDeepLink(ActionEnum.ConfirmWithdrawal, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateConfirmedTransferLink(GenerateTransferLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_transfer_email_confirm&jw_operation_id={request.OperationId}");
            return GenerateDeepLink(ActionEnum.ConfirmTransfer, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateInviteFriendLink(GenerateInviteFriendLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=InviteFriend&");
            return GenerateDeepLink(ActionEnum.InviteFriend, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateKycVerificationLink(GenerateKycVerificationLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=KycVerification&");
            return GenerateDeepLink(ActionEnum.KycVerification, request.DeviceType, request.Brand, deepLinkParameters);
            
        }

        public (string longLink, string shortLink) GenerateDepositStartLink(GenerateDepositStartLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=DepositStart&");
            return GenerateDeepLink(ActionEnum.DepositStart, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateTradingStartLink(GenerateTradingStartLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=TradingStart&");
            return GenerateDeepLink(ActionEnum.TradingStart, request.DeviceType, request.Brand, deepLinkParameters);        
        }

        public (string longLink, string shortLink) GenerateVerifyWithdrawalLink(GenerateVerifyWithdrawalLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=VerifyWithdrawal&jw_operation_id={request.OperationId}&jw_code={request.Code}");
            return GenerateDeepLink(ActionEnum.VerifyWithdrawal, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateVerifyTransferLink(GenerateVerifyTransferLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=VerifyTransfer&jw_operation_id={request.OperationId}&jw_code={request.Code}");
            return GenerateDeepLink(ActionEnum.VerifyTransfer, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateEarnLandingLink(GenerateEarnLandingLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=EarnLanding&");
            return GenerateDeepLink(ActionEnum.EarnLanding, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateKycSuccessLink(GenerateKycSuccessLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=KycSuccess&");
            return GenerateDeepLink(ActionEnum.KycSuccess, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateKycFailLink(GenerateKycFailLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=KycFail&");
            return GenerateDeepLink(ActionEnum.KycFail, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateRecurringBuyLink(GenerateRecurringBuyLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=RecurringBuyStart&");
            return GenerateDeepLink(ActionEnum.RecurringBuyStart, request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateProfileDeleteLink(GenerateDeleteProfileLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ProfileDeleteConfirm&jw_code={request.Code}");
            return GenerateDeepLink(ActionEnum.ProfileDelete, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateHighYieldLink(GenerateHighYieldLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=HighYield&");
            return GenerateDeepLink(ActionEnum.HighYield, request.DeviceType, request.Brand, deepLinkParameters);        
        }

        public (string longLink, string shortLink) GenerateSupportLink(GenerateSupportLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command={ActionEnum.SupportPage.GetString()}&");
            return GenerateDeepLink(ActionEnum.SupportPage, request.DeviceType, request.Brand, deepLinkParameters);        
        }

        public (string longLink, string shortLink) GenerateDepositSuccessLink(GenerateDepositSuccessLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command={ActionEnum.DepositSuccess.GetString()}&jw_operation_id={request.OperationId}");
            return GenerateDeepLink(ActionEnum.DepositSuccess, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateKycDocumentsDeclinedLink(GenerateKycDocsDeclinedLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command={ActionEnum.KycDocumentsDeclined.GetString()}&");
            return GenerateDeepLink(ActionEnum.KycDocumentsDeclined, request.DeviceType, request.Brand, deepLinkParameters);
        }

        private (string longLink, string shortLink) GenerateDeepLink(ActionEnum action, DeviceTypeEnum device, string brand, string paramString)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(brand));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for brand {brand}");

            var baseLinks = parameters.Links?.FirstOrDefault(t => t.Action == action);
            if (baseLinks == null)
                throw new Exception($"Unable to find links for this action: {action}");
            
            var linkBase = device switch
            {
                DeviceTypeEnum.Android => baseLinks.BaseLinkAndroid,
                DeviceTypeEnum.Ios => baseLinks.BaseLinkIos,
                DeviceTypeEnum.Unknown => baseLinks.BaseLinkDefault,
                _ => throw new ArgumentOutOfRangeException(nameof(DeviceTypeEnum),$"Unable to find base link")
            };
            
            var deepLink = linkBase.Contains('?') 
                ? $"{linkBase}&{paramString}" 
                : $"{linkBase}?{paramString}";

            return ($"{parameters.DomainUriPrefix}/?link={HttpUtility.UrlEncode(deepLink)}&apn={parameters.AndroidPackageName}&ibi={parameters.IosBundleId}&isi={parameters.IosStoreId}&efr=1", deepLink);
        }
    }
}