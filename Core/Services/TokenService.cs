using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Api.Core.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ErrorContext _errorContext;
        public bool IsBearerValid { get; private set; }

        public TokenService(IHttpContextAccessor IHttpContextAccessor, IConfiguration configuration, ErrorContext errorContext)
        {
            _configuration = configuration;
            _httpContextAccessor = IHttpContextAccessor;
            _errorContext = errorContext;
        }
        public string GenerateToken(UsuarioModel usuario)
        {
            var tokenHander = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Token")["Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(nameof(ClaimTypes.Name), usuario.UserName),
                    new Claim(nameof(ClaimTypes.Role), usuario.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHander.CreateToken(tokenDescriptor);
            return tokenHander.WriteToken(token);
        }
        public void ValidateToken() 
        {
            try
            {
                ValidateBearer();
                if (_errorContext.HasError)
                    IsBearerValid = false;
            }
            catch (Exception e)
            {
                _errorContext.ClearErrors();
                _errorContext.AddError("Erro na Autenticação", e.Message);
            }
        }

        private void ValidateBearer()
        {
            IsBearerValid = true;
               var jwtHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
            if (string.IsNullOrEmpty(jwtHeader))
            {
                _errorContext.AddError("Não Permitido", "Token de autorização não encontrado!");
                return;
            }
            string jwt = jwtHeader.ToString().Substring("Bearer ".Length).Trim();
            if (string.IsNullOrEmpty(jwt))
            {
                _errorContext.AddError("Não Permitido", "Token de autorização não encontrado!");
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(jwt)) 
            {
                _errorContext.AddError("Não Permitido", "Formato de token não suportado!");
                return;
            }
            var token = handler.ReadJwtToken(jwt);
            if (token.ValidTo < DateTime.UtcNow)
            {
                _errorContext.AddError("Não Permitido", "Token expirado");
                return;
            }

            if (!int.TryParse(token.Claims.FirstOrDefault(x => x.Type == nameof(ClaimTypes.Role))?.Value, out int role))
            {
                _errorContext.AddError("Não Permitido", "Role inválida");
                return;
            }

            if(role != 1)
            {
                _errorContext.AddError("Não Permitido", "Role não permitida");
            }
        }
    }
}
