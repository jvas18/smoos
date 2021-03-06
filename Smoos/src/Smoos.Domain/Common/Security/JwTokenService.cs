using System;
using System.Security.Claims;
using Jwks.Manager.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Smoos.Domain.Common._Config;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Models;

namespace Smoos.Domain.Common.Security
{
    public class JwTokenService : IJwtService
	{
		private readonly JwTokenConfig _jwTokenConfig;
		private readonly IJsonWebKeySetService _jsonWebKeySetService;

		public JwTokenService(JwTokenConfig jwTokenConfig, IJsonWebKeySetService jsonWebKeySetService)
		{
			_jwTokenConfig = jwTokenConfig;
			_jsonWebKeySetService = jsonWebKeySetService;
		}

		public virtual void Generate<T>(ClaimsIdentity identity, ref T jwToken) where T : JwToken
		{

			if (jwToken == null)
				throw new ArgumentException("jwToken objetc is null");

			var handler = new JsonWebTokenHandler();

			var descriptor = new SecurityTokenDescriptor
			{
				Issuer = _jwTokenConfig.Issuer,
				Audience = _jwTokenConfig.Audience,
				SigningCredentials = _jsonWebKeySetService.GetCurrent(),
				Subject = identity,
				NotBefore = DateTime.UtcNow,
				Expires = DateTime.UtcNow.AddHours(_jwTokenConfig.ExpirationHours)
			};

			jwToken.AccessToken = handler.CreateToken(descriptor);
			jwToken.ExpiresIn = descriptor.Expires.Value;
			jwToken.NotBefore = descriptor.NotBefore.Value;
		}

		public TokenValidationResult Validate(string token)
		{
			var handler = new JsonWebTokenHandler();

			var key = _jsonWebKeySetService?.GetCurrent().Key;

			return handler.ValidateToken(token,
				new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateIssuer = true,
					ValidIssuer = _jwTokenConfig.Issuer,
					IssuerSigningKey = key
				});
		}
	}
}

