using AdaTech._LoginMiddleware.WebAPI.Models;
using AdaTech._LoginMiddleware.WebAPI.Utilities.Data;
using Microsoft.AspNetCore.Mvc;

namespace AdaTech._LoginMiddleware.WebAPI.Views
{
    public static class RegisterViews
    {
        public static IActionResult RegistrarUsuario (UserRequest user)
        {
            var usuarioExistente = DataEntity.Usuarios.FirstOrDefault(u => u.Cpf == user.Cpf);

            if (usuarioExistente != null)
            {
                return new NotFoundObjectResult("Usuário já cadastrado!");
            }

            var novoUsuario = new Usuario
            {
                Id = DataEntity.Usuarios.Count + 1,
                Nome = user.Nome,
                Senha = user.Senha,
                Cpf = user.Cpf,
                Email = user.Email,
                Is_ativo = true,
                Is_admin = false,
                Is_staff = false,
                Is_logado = false
            };

            DataEntity.Usuarios.Add(novoUsuario);

            return new OkObjectResult(novoUsuario);
        }
    }
}
