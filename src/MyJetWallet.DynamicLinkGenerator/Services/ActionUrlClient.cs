using Service.PushNotification.Domain.Models.Enums;

namespace MyJetWallet.DynamicLinkGenerator.Services;

public static class ActionUrlClient
{
    public static string GenerateOperationHistoryUrl(string baseUrl, string operationId)
    {
        return $"{baseUrl}action/{JwAction.jw_operation_history}/jw_operation_id/{operationId}";
    }
}