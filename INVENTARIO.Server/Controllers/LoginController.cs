using INVENTARIO.Server.DTOS;
using INVENTARIO.Server.Models;
using INVENTARIO.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace INVENTARIO.Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        public readonly IRepository<Usuarios> _usuariosRepository;
        private readonly IConfiguration _configuration;

        public LoginController(IRepository<Usuarios> usuariosRepository, IConfiguration configuration)
        {
            _usuariosRepository = usuariosRepository;
            _configuration = configuration;
        }


        [HttpPost(template: "login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var lista = await _usuariosRepository.GetAllAsync();

                var usuario = lista.FirstOrDefault(u =>
                    u.USUARIO == loginRequest.Usuario &&
                    u.CONTRASENA == loginRequest.Contrasena);

                if (usuario == null)
                    return Unauthorized("Usuario o contraseña incorrectos");

                // 🔐 Crear claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, usuario.USUARIO),
                    new Claim("empId", usuario.empId.ToString())
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                );

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(
                        Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])
                    ),
                    signingCredentials: creds
                );

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    token = jwt,
                    usuario = usuario.USUARIO
                });
            }
            catch (Exception exc)
            {
                return StatusCode(500, $"Error: {exc.Message}");
            }
        }
    }
}
