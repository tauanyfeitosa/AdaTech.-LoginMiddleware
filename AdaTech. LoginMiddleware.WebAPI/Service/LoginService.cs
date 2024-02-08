using AdaTech._LoginMiddleware.WebAPI.Utilities.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech._LoginMiddleware.WebAPI.Service
{
    public static class LoginService
    {
        public static IActionResult VerificarUsuarioLogado (int id)
        {
            var usuarioLogado = DataEntity.Usuarios.FirstOrDefault(u => u.Id == id && u.Is_admin && u.Is_ativo);

            if (usuarioLogado == null)
            {
                return new NotFoundObjectResult("Acesso não permitido");
            }

            return new OkObjectResult(usuarioLogado);
        }

        public static IActionResult VerificarUsuarioAdmin (int id)
        {
            var usuarioLogado = DataEntity.Usuarios.FirstOrDefault(u => u.Id == id && u.Is_admin && u.Is_ativo && u.Is_staff);

            if (usuarioLogado == null)
            {
                return new NotFoundObjectResult("Acesso não permitido");
            }

            return new OkObjectResult(usuarioLogado);
        }

        public static IActionResult VerificarLogin (string login, string senha)
        {
            var usuarioLogado = DataEntity.Usuarios.FirstOrDefault(u => u.Cpf == login && u.Is_ativo);

            if (usuarioLogado == null)
            {
                return new NotFoundObjectResult("Login inválido!");
            }

            if (usuarioLogado.Senha != senha)
            {
                return new NotFoundObjectResult("Senha inválida!");
            }

            usuarioLogado.Is_logado = true;

            return new OkObjectResult(usuarioLogado);
        }

        public static IActionResult VerificarLogout (int id)
        {
            var usuarioLogado = DataEntity.Usuarios.FirstOrDefault(u => u.Id == id && u.Is_ativo && u.Is_logado);

            if (usuarioLogado == null)
            {
                return new NotFoundObjectResult("Usuário não encontrado!");
            }

            usuarioLogado.Is_logado = false;

            return new OkObjectResult(usuarioLogado);
        }
    }
}
