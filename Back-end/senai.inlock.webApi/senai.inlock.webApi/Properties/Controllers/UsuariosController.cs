using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Properties.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Properties.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost("Login")]

        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

            if (usuarioBuscado == null)

            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]

            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "inLock.webAPI",
                audience: "inLock.webAPI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(45),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
