﻿namespace DigitalKeyMarket.BL.Auth.Model;

public class TokensResponse
{
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}