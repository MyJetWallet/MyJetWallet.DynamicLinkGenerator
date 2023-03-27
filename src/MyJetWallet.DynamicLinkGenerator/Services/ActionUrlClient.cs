using Service.PushNotification.Domain.Models.Enums;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public static class ActionUrlClient
{
    public static string GenerateOperationHistoryUrl(string baseUrl, string operationId)
    {
        return $"{baseUrl}action/{JwAction.jw_operation_history}/jw_operation_id/{operationId}";
    }
    
    public static string GenerateKycDocumentsApprovedUrl(string baseUrl)
    {
        return $"{baseUrl}action/{JwAction.jw_kyc_documents_approved}";
    }

    public static string GenerateKycDocumentsDeclinedUrl(string baseUrl)
    {
        return $"{baseUrl}action/{JwAction.jw_kyc_documents_declined}";
    }

    public static string GenerateKycBannedUrl(string baseUrl)
    {
        return $"{baseUrl}action/{JwAction.jw_kyc_banned}";
    }

}