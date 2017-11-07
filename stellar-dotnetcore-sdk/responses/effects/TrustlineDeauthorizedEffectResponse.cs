﻿using stellar_dotnetcore_sdk.requests;

namespace stellar_dotnetcore_sdk.responses.effects
{
    /// <summary>
    ///     Represents trustline_deauthorized effect response.
    ///     See: https://www.stellar.org/developers/horizon/reference/resources/effect.html
    ///     <seealso cref="EffectsRequestBuilder" />
    ///     <seealso cref="Server" />
    /// </summary>
    public class TrustlineDeauthorizedEffectResponse : TrustlineAuthorizationResponse
    {
        public TrustlineDeauthorizedEffectResponse(KeyPair trustor, string assetType, string assetCode) 
            : base(trustor, assetType, assetCode)
        {
        }
    }
}