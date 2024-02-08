using AdaTech._LoginMiddleware.WebAPI.Models;
using AdaTech._LoginMiddleware.WebAPI.Utilities.Data;
using AdaTech._LoginMiddleware.WebAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech._LoginMiddleware.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return DataEntity.Usuarios;
        }

        [HttpGet("byId")]
        public IActionResult GetById([FromQuery]  int id)
        {
            return LoginService.VerificarUsuarioLogado(id);
        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromQuery] string login, [FromQuery] string senha)
        {
            return LoginService.VerificarLogin(login, senha);
        }

        [HttpPost("registro")]
        public IActionResult PostRegistro([FromBody] UserRequest user)
        {
            return RegisterService.RegistrarUsuario(user);
        }

        [HttpPost("sair")]
        public IActionResult PostLogout([FromQuery]  int id)
        {
            return LoginService.VerificarLogout(id);
        }
    }
}
