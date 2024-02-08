using AdaTech._LoginMiddleware.WebAPI.Data;
using AdaTech._LoginMiddleware.WebAPI.Models;
using AdaTech._LoginMiddleware.WebAPI.Views;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech._LoginMiddleware.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Usuario> Get([FromQuery]int id)
        {
            return DataEntity.Usuarios;
        }

        [HttpGet("byId")]
        public IActionResult GetById([FromQuery]  int id)
        {
            return LoginViews.VerificarUsuarioLogado(id);
        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromQuery] string login, [FromQuery] string senha)
        {
            return LoginViews.VerificarLogin(login, senha);
        }

        [HttpPost("registro")]
        public IActionResult PostRegistro([FromBody] UserRequest user)
        {
            return RegisterViews.RegistrarUsuario(user);
        }

        [HttpPost("sair")]
        public IActionResult PostLogout([FromQuery]  int id)
        {
            return LoginViews.VerificarLogout(id);
        }
    }
}
