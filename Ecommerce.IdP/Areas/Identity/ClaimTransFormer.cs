using Ecommerce.IdP.Models;
using Ecommerce.IdP.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ecommerce.IdP.Areas.Identity;

public class ClaimTransFormer:IClaimTransFormer
{
    private readonly IUserStore<EcommerceUser> _userStore;
    public ClaimTransFormer(IUserStore<EcommerceUser> userStore)
    {
        _userStore = userStore;
    }


    public async Task<ClaimsPrincipal> TranformAsync(ClaimsPrincipal principal)
    {
        var clonePrincipal = principal.Clone();

        if (clonePrincipal.Identities is null)
            return clonePrincipal;

        var identity = (ClaimsIdentity)(clonePrincipal.Identity);

        var existingClaim = identity.Claims.FirstOrDefault(p => p.Type == ECommerceClaimTypes.Calim1);

        if (existingClaim != null)
            return clonePrincipal;

        var nameIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (nameIdClaim is null)
            return clonePrincipal;

        var user = await _userStore.FindByIdAsync(nameIdClaim.Value, CancellationToken.None);
        
        identity.AddClaim(new Claim(ECommerceClaimTypes.Calim1, "ValueClaim1"));

        return clonePrincipal;
    }
}
