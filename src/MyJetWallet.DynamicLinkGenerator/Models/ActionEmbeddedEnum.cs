using System;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public enum ActionEmbeddedEnum
{
    EmbeddedOperationHistory = 1,
    EmbeddedDiscovery = 2,
}

public static class EmbeddedActionExtensions
{
    public static string GetString(this ActionEmbeddedEnum actionEnum) =>
        actionEnum switch
        {
            ActionEmbeddedEnum.EmbeddedOperationHistory => "sc_history",
            ActionEmbeddedEnum.EmbeddedDiscovery => "sc_discovery",
            _ => throw new ArgumentOutOfRangeException(nameof(actionEnum), actionEnum, null)
        };
}