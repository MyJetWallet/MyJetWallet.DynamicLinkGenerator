using System;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public enum ActionEmbeddedEnum
{
    EmbeddedOperationHistory = 1,
}

public static class EmbeddedActionExtensions
{
    public static string GetString(this ActionEmbeddedEnum actionEnum) =>
        actionEnum switch
        {
            ActionEmbeddedEnum.EmbeddedOperationHistory => "sc_history",
            
            _ => throw new ArgumentOutOfRangeException(nameof(actionEnum), actionEnum, null)
        };
}