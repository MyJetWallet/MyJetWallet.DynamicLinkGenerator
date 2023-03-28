using System.Diagnostics.CodeAnalysis;

namespace Service.PushNotification.Domain.Models.Enums
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum JwAction
    {
       None,
       jw_operation_history = 7,
       jw_kyc_documents_approved = 10,
       jw_kyc_documents_declined = 11,
       jw_kyc_banned = 12,
       jw_crypto_withdrawal_decline = 13,
    }
}
