﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

public static class Config
{
    // Identity Resources (used for OpenID Connect)
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource("ecommerce",new [] {"role"})
        };

    // API Scopes
    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("ecommerceapi", "Ecommerce API Access")
        };

    // Clients that can access your IdentityServer
    public static IEnumerable<Client> Clients =>
        new Client[]
        {
        new Client
{
            
        ClientId = "ecommerce-client",
        ClientName = "Ecommerce Web App",
        ClientSecrets = { new Secret("9f1b2a1e-71b0-4c62-93fb-e4c5a10f8de7".Sha256()) },
        AllowedGrantTypes = GrantTypes.Code,
        RequireConsent = false, // Typically false for better UX
        RedirectUris = {
            "https://localhost:7060/swagger/index.html", // Match your token request
            "https://localhost:7060/swagger/oauth2-redirect.html" // For Swagger UI
        },
        PostLogoutRedirectUris = { "https://localhost:7060/swagger/oauth2-redirect.html" },
        AllowedScopes = { "openid", "profile", "email", "ecommerceapi" },
        AllowOfflineAccess = true,
        RequirePkce = false, // Set to true for better security
        AlwaysIncludeUserClaimsInIdToken = true
}
        
        };
}
