using System;
using System.Web;
using MyJetWallet.DynamicLinkGenerator.Models;
using MyJetWallet.DynamicLinkGenerator.NoSql;
using MyNoSqlServer.Abstractions;
using Service.DynamicLinkGenerator.Domain.Models.Enums;

namespace MyJetWallet.DynamicLinkGenerator.Services
{
    public class DynamicLinkClient : IDynamicLinkClient
    {
        private readonly IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> _reader;

        public DynamicLinkClient(IMyNoSqlServerDataReader<DynamicLinkSettingsNoSql> reader)
        {
            _reader = reader;
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
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ForgotPassword&jw_token={request.Token}");
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
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_withdrawal_verify&jw_operation_id={request.OperationId}&jw_token={request.Token}");
            return GenerateDeepLink(ActionEnum.VerifyWithdrawal, request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateVerifyTransferLink(GenerateVerifyTransferLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_transfer_verify&jw_operation_id={request.OperationId}&jw_token={request.Token}");
            return GenerateDeepLink(ActionEnum.VerifyTransfer, request.DeviceType, request.Brand, deepLinkParameters);
        }

        private (string longLink, string shortLink) GenerateDeepLink(ActionEnum action, DeviceTypeEnum device, string brand, string paramString)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(brand));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for brand {brand}");

            if (!parameters.LinksMap.TryGetValue(action, out var baseLinks))
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

            return ($"{parameters.DomainUriPrefix}/?link={HttpUtility.UrlEncode(deepLink)}&apn={parameters.AndroidPackageName}&ibi={parameters.IosBundleId}", deepLink);
        }
    }
}