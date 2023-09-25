using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GC.Consulta.Domain.Entidade;
using GC.Consulta.Servico.Interface;

namespace GC.Consulta.WebApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        private readonly IUsuarioServico usuarioService;

        public AutenticacaoController(IConfiguration configuration, IUsuarioServico usuarioService)
        {
            Configuration = configuration;
            this.usuarioService = usuarioService;
        }

        /// <summary>
        /// Autentica o usuário através do e-mail e senha
        /// </summary>
        /// <returns>Token de acesso às APIs</returns>
        [HttpPost]
        public async Task<IActionResult> Validar([FromBody] Credenciais credenciais)
        {
            try
            {
                Usuario usuario = await usuarioService.Validar(credenciais.Email, credenciais.Senha);
                Autenticacao tokenFinal = new Autenticacao();
                string tokenJWT = string.Empty;

                if (usuario != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.UniqueName, credenciais.Email),
                    new Claim("usuarioID", usuario.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenConfiguration")["Secret"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var expiration = DateTime.UtcNow.AddMonths(1);
                    JwtSecurityToken token = new JwtSecurityToken(
                       issuer: null,
                       audience: null,
                    claims: claims,
                       expires: expiration,
                       signingCredentials: creds);

                    tokenJWT = new JwtSecurityTokenHandler().WriteToken(token);

                    tokenFinal = new Autenticacao()
                    {
                        Token = tokenJWT,
                        ExpirationDate = expiration,
                        Usuario = usuario
                    };

                }
                else
                    return NotFound("Usuário não localizado com o email e senha informados");

                return Ok(tokenFinal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
