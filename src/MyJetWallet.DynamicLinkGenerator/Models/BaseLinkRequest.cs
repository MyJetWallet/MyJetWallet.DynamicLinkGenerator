using MyJetWallet.Domain;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public abstract class BaseLinkRequest
{
    public PlatformType Platform { get; set; }
}