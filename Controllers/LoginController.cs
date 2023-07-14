using Entities;
using Imobiliaria.Infra;
using Login.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Login.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ImobiliariaContext _context;

        public LoginController(ImobiliariaContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var usuario = _context.Usuario.FirstOrDefault(x => x.Login == model.Login && x.Senha == model.Senha);

            if (usuario == null)
                return BadRequest("Login ou Senha Inválidos!");

            var token = GerarJwtToken(usuario);

            return Ok(new { Token = token, IdUsuario = usuario.IdUsuario, Nome = usuario.Nome, Cpf = usuario.Cpf });
        }

        private string GerarJwtToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = GerarChaveJwt();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Login),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuario),
                    new Claim("idUsuario", usuario.IdUsuario.ToString()),
                    new Claim("nome", usuario.Nome)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static byte[] chaveJwt;

        private byte[] GerarChaveJwt()
        {
            if (chaveJwt == null)
            {
                var rng = new RNGCryptoServiceProvider();
                chaveJwt = new byte[256];
                rng.GetBytes(chaveJwt);
            }
            return chaveJwt;
        }
    }
}