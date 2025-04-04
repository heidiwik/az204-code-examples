﻿using System.Threading.Tasks;
using Microsoft.Identity.Client;

public class Program
{
    private const string _clientId = "";
    private const string _tenantId = "";

    public static async Task Main(string[] args)
    {
        var app = PublicClientApplicationBuilder
        .Create(_clientId)
        .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
        .WithRedirectUri("http://localhost")
        .Build();

        string[] scopes = { "user.read"};

        AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

        Console.WriteLine($"Token:\t{result.AccessToken}");
    }
}