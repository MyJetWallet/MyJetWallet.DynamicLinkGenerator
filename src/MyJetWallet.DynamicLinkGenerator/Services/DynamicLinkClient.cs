using System;
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

        public (string longLink, string shortLink) GenerateLoginLink(GenerateLoginLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=Login&");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateConfirmEmailLink(GenerateConfirmEmailLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ConfirmEmail&jw_code={request.Code}");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateForgotPasswordLink(GenerateForgotPasswordLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=ForgotPassword&jw_token={request.Token}");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        public (string longLink, string shortLink) GenerateConfirmWithdrawalLink(GenerateWithdrawalLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_withdrawal_email_confirm&jw_operation_id={request.OperationId}");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateConfirmTransferLink(GenerateTransferLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, $"jw_command=jw_transfer_email_confirm&jw_operation_id={request.OperationId}");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }

        public (string longLink, string shortLink) GenerateInviteFriendLink(GenerateInviteFriendLinkRequest request)
        {
            var deepLinkParameters = "";
            deepLinkParameters = string.Concat(deepLinkParameters, "jw_command=InviteFriend&");
            return GenerateDeepLink(request.DeviceType, request.Brand, deepLinkParameters);
        }
        
        private (string longLink, string shortLink) GenerateDeepLink(DeviceTypeEnum device, string brand, string paramString)
        {
            var parameters = _reader.Get(DynamicLinkSettingsNoSql.GeneratePartitionKey(),
                DynamicLinkSettingsNoSql.GenerateRowKey(brand));
            
            if (parameters == null)
                throw new ArgumentException($"Unable to get link parameters for brand {brand}");
            
            var linkBase = device switch
            {
                DeviceTypeEnum.Android => parameters.LinkBaseUrlAndroid,
                DeviceTypeEnum.Ios => parameters.LinkBaseUrlIos,
                DeviceTypeEnum.Unknown => parameters.LinkBaseUrlDefault,
                _ => throw new ArgumentOutOfRangeException(nameof(DeviceTypeEnum),$"Unable to find base link")
            };
            
            
            var deepLink = linkBase.Contains('?') 
                ? $"{linkBase}&{paramString}" 
                : $"{linkBase}?{paramString}";

            return ($"{parameters.DomainUriPrefix}/?link={HttpUtility.UrlEncode(deepLink)}&apn={parameters.AndroidPackageName}&ibi={parameters.IosBundleId}", deepLink);
        }
    }
}