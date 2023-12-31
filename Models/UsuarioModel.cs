﻿namespace Imobiliaria.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public string TipoUsuario { get; set; }

        public class UsuarioCadastrarImovelModel
        {
            public int IdUsuario { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Cpf { get; set; }
        }

        public class AlterarSenhaModel
        {
            public string Senha { get; set; }
            public string NovaSenha { get; set; }
            public string ConfirmarNovaSenha { get; set; }
        }

        public class ObterUsuarioModel
        {
            public int IdUsuario { get; set; }
            public string Nome { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public string Cpf { get; set; }
            public string TipoUsuario { get; set; }
            public string Situacao { get; set; }
        }
    }
}
