﻿using AdaTech._LoginMiddleware.WebAPI.Models;

namespace AdaTech._LoginMiddleware.WebAPI.Utilities.Data
{
    public static class DataEntity
    {
        public static List<User> Usuarios = new List<User>
        {
            new User
            {
                Id = 1,
                Nome = "Admin",
                Senha = "admin",
                Cpf = "12345678900",
                Email = "",
                Is_ativo = true,
                Is_admin = true,
                Is_staff = true,
                Is_logado = false
            }
        };
    }
}
