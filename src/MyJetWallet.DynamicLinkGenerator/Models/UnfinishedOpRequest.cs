using System;

namespace MyJetWallet.DynamicLinkGenerator.Models;

public class UnfinishedOpRequest
{
    public string Brand { get; set; }
    public string FromAsset { get; set; }
    public string ToAsset { get; set; }
    public string Amount { get; set; }
    public bool BuyFixed { get; set; }
}