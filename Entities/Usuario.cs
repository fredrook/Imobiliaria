namespace Entities
{
    public class Usuario : BaseModel
    {
        public int IdUsuario { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string TipoUsuario { get; set; }
      
        public Usuario() { }

        public Usuario(string login, string nome, string email, string cpf, string tipoUsuario, string usuarioInclusao)
        {
            this.Login = ValidaDomain.ValidaCampoNulo("Login", login);
            this.Nome = ValidaDomain.ValidaCampoNulo("Nome", nome);
            this.Email = ValidaDomain.ValidaEmail(email);
            this.Cpf = ValidaDomain.ValidaCpfCnpj(cpf);
            this.TipoUsuario = ValidaDomain.ValidaCampoNulo("Tipo Usuário", tipoUsuario);
            SetUsuarioInclusao(usuarioInclusao);

            switch (tipoUsuario)
            {
                case "Root":
                case "Administrador":
                case "Atendente":
                case "Corretor":
                case "Locador":
                case "Locatário":
                    this.IdUsuario = ValidaDomain.ValidaEntidadeNull("Usuario", IdUsuario);
                    break;

                default:
                    throw new Exception("Perfil obrigatório");
            }
            this.Senha = "123456";
        }

        public void AlterarSenha(string senha, string primeiroAcesso)
        {
            this.Senha = senha;

            if (string.IsNullOrEmpty(senha))
                throw new Exception("Senha obrigatória");
        }

        public void ResetarSenha(string usuarioAlteracao)
        {
            this.Senha = "123456";
            SetUsuarioAlteracao(usuarioAlteracao);
        }

        public void Inativar(string usuarioAlteracao)
        {
            this.Situacao = "Inativo";
            SetUsuarioAlteracao(usuarioAlteracao);
        }

        public void Ativar(string usuarioAlteracao)
        {
            this.Situacao = "Ativo";
            SetUsuarioAlteracao(usuarioAlteracao);
        }

        internal void Excluir(string usuarioExclusao)
        {
            this.Situacao = "Excluir";
            SetUsuarioExclusao(usuarioExclusao);
        }
    }
}
