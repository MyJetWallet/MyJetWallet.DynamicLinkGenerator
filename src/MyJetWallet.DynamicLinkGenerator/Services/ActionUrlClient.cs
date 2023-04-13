using MyJetWallet.DynamicLinkGenerator.Models;

namespace MyJetWallet.DynamicLinkGenerator.Services;

// public static class ActionUrlClient
// {
//     public static string GenerateOperationHistoryUrl(string baseUrl, string operationId)
//     {
//         return $"{baseUrl}action/{ActionEnum.OperationHistory.GetString()}/jw_operation_id/{operationId}";
//     }
//     
//     public static string GenerateKycDocumentsApprovedUrl(string baseUrl)
//     {
//         return $"{baseUrl}action/{ActionEnum.KycDocumentsApproved.GetString()}";
//     }
//
//     public static string GenerateKycDocumentsDeclinedUrl(string baseUrl)
//     {
//         return $"{baseUrl}action/{ActionEnum.KycDocumentsDeclined.GetString()}";
//     }
//
//     public static string GenerateKycBannedUrl(string baseUrl)
//     {
//         return $"{baseUrl}action/{ActionEnum.KycBanned.GetString()}";
//     }
//     
//     public static string GenerateCryptoWithdrawalDeclineUrl(string baseUrl, string asset)
//     {
//         return $"{baseUrl}action/{ActionEnum.WithdrawalDecline.GetString()}/jw_asset/{asset}";
//     }
//
// }