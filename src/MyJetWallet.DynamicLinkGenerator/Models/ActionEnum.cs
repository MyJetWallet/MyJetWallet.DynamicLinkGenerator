using System;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public enum ActionEnum
{
    None,
    Login,
    ConfirmEmail,
    ForgotPassword,
    ConfirmWithdrawal,
    ConfirmTransfer,
    InviteFriend,
    KycVerification,
    DepositStart,
    TradingStart,
    VerifyWithdrawal,
    VerifyTransfer,
    EarnLanding,
    KycSuccess,
    KycFail,
    RecurringBuyStart,
    ProfileDelete,
    HighYield,
    OperationHistory, //jw_operation_history = 7,
    KycDocumentsApproved, //jw_kyc_documents_approved = 10,
    KycDocumentsDeclined, //jw_kyc_documents_declined = 11,
    KycBanned, //jw_kyc_banned = 12,
    WithdrawalDecline, //jw_crypto_withdrawal_decline = 13,
    DepositSuccess, 
    SupportPage,
    GiftIncoming,
    GiftReminder,
    GiftCancelled,
    GiftExpired,
    Jar
}

public static class ActionExtensions
{
    public static string GetString(this ActionEnum actionEnum) =>
        actionEnum switch
        {
            ActionEnum.Login => "Login",
            ActionEnum.ConfirmEmail => "ConfirmEmail",
            ActionEnum.ForgotPassword => "ForgotPassword",
            ActionEnum.ConfirmWithdrawal => "jw_withdrawal_email_confirm",
            ActionEnum.ConfirmTransfer => "jw_transfer_email_confirm",
            ActionEnum.InviteFriend => "InviteFriend",
            ActionEnum.KycVerification => "KycVerification",
            ActionEnum.DepositStart => "DepositStart",
            ActionEnum.TradingStart => "TradingStart",
            ActionEnum.VerifyWithdrawal => "VerifyWithdrawal",
            ActionEnum.VerifyTransfer => "VerifyTransfer",
            ActionEnum.EarnLanding => "EarnLanding",
            ActionEnum.KycSuccess => "KycSuccess",
            ActionEnum.KycFail => "KycFail",
            ActionEnum.RecurringBuyStart => "RecurringBuyStart",
            ActionEnum.ProfileDelete => "ProfileDelete",
            ActionEnum.HighYield => "HighYield",
            ActionEnum.OperationHistory => "jw_operation_history",
            ActionEnum.KycDocumentsApproved => "jw_kyc_documents_approved",
            ActionEnum.KycDocumentsDeclined => "jw_kyc_documents_declined",
            ActionEnum.KycBanned => "jw_kyc_banned",
            ActionEnum.WithdrawalDecline => "jw_crypto_withdrawal_decline",
            //ActionEnum.DepositSuccess => "jw_deposit_successful",
            ActionEnum.SupportPage => "jw_support_page",
            // ActionEnum.GiftIncoming => "jw_gift_incoming",
            // ActionEnum.GiftReminder => "jw_gift_remind",
            // ActionEnum.GiftCancelled => "jw_gift_cancelled",
            // ActionEnum.GiftExpired => "jw_gift_expired",
            ActionEnum.None => string.Empty,
            ActionEnum.DepositSuccess => "jw_operation_history",
            ActionEnum.GiftIncoming => "jw_operation_history",
            ActionEnum.GiftReminder => "jw_operation_history",
            ActionEnum.GiftCancelled => "jw_operation_history",
            ActionEnum.GiftExpired => "jw_operation_history",
            ActionEnum.Jar => "jar",
            _ => throw new ArgumentOutOfRangeException(nameof(actionEnum), actionEnum, null)
        };
}