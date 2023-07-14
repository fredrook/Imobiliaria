using Entities;
using Imobiliaria.Infra;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static Imobiliaria.Models.UsuarioModel;

namespace Imobiliaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ImobiliariaContext _context;

        public UsuarioController(ImobiliariaContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        [Route("salvarUsuario")]
        public IActionResult SalvarUsuario([FromBody] UsuarioModel model)
        {
            var res = _context.Usuario.FirstOrDefault(x => x.Login == model.Login);

            if (res != null)
                return BadRequest("Usuário já cadastrado");

            var usuario = new Usuario(
                model.Login,
                model.Nome,
                model.Email,
                model.Cpf,
                model.TipoUsuario,
                User.Identity.Name
            );

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("listarUsuario")]
        public IActionResult ListarUsuario([FromBody] FiltroUsuarioModel model)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);

            ICollection<UsuarioModel> resultado = null;
            Expression<Func<Usuario, bool>> filtroNome = registro => true;
            Expression<Func<Usuario, bool>> filtroTipo = registro => true;

            if (!string.IsNullOrEmpty(model.Nome))
                filtroNome = (Usuario registro) => registro.Nome.Contains(model.Nome);

            if (!string.IsNullOrEmpty(model.TipoUsuario))
                filtroTipo = (Usuario registro) => registro.TipoUsuario.Equals(model.TipoUsuario);

            resultado = _context.Usuario
                 .Where(filtroNome)
                 .Where(filtroTipo)
                 .Select(m => new UsuarioModel
                 {
                     IdUsuario = m.IdUsuario,
                     Nome = m.Nome,
                     Email = m.Email,
                     Cpf = m.Cpf,
                     TipoUsuario = m.TipoUsuario
                 }).ToList();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("obterUsuario")]
        public IActionResult ObterUsuario(int idUsuario)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (usuarioLogado == null)
                return BadRequest("Usuário Logado não encontrado!");

            var usuario = _context.Usuario.FirstOrDefault(x => x.IdUsuario == idUsuario);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            var model = new ObterUsuarioModel();
            model.TipoUsuario = usuario.TipoUsuario;
            model.IdUsuario = usuario.IdUsuario;
            model.Login = usuario.Login;
            model.Email = usuario.Email;
            model.Nome = usuario.Nome;
            model.Cpf = usuario.Cpf;
            model.Situacao = usuario.Situacao;

            return Ok(model);
        }

        [HttpGet]
        [Route("desativarUsuario")]
        public IActionResult DesativarUsuario(string cpf)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (usuarioLogado == null)
                return BadRequest("Usuário Logado não encontrado!");

            var usuario = _context.Usuario.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            usuario.Inativar(User.Identity.Name);

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("ativarUsuario")]
        public IActionResult AtivarUsuario(string cpf)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (usuarioLogado == null)
                return BadRequest("Usuário Logado não encontrado!");

            var usuario = _context.Usuario.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            usuario.Ativar(User.Identity.Name);

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("resetarSenha")]
        public IActionResult ResetarSenha(string cpf)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (usuarioLogado == null)
                return BadRequest("Usuário Logado não encontrado!");

            var usuario = _context.Usuario.FirstOrDefault(x => x.Cpf == cpf);
            if (usuario == null)
                return BadRequest("Usuário não encontrado");

            usuario.ResetarSenha(User.Identity.Name);

            _context.Usuario.Update(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("verificarLoginDuplicado")]
        public IActionResult VerificarLoginDuplicado(string login)
        {
            var res = _context.Usuario.FirstOrDefault(x => x.Login == login);
            if (res == null)
                return Ok(true);
            else
                return Ok(false);
        }

        [HttpPost]
        [Route("alterarSenha")]
        public IActionResult AlterarSenha([FromBody] AlterarSenhaModel model)
        {
            var usuarioLogado = _context.Usuario.FirstOrDefault(x => x.Login == User.Identity.Name);
            if (usuarioLogado == null)
                return BadRequest("Usuário Logado não encontrado!");

            if (model.Senha != usuarioLogado.Senha)
                return BadRequest("Senha atual incorreta");

            if (model.NovaSenha != model.ConfirmarNovaSenha)
                return BadRequest("Nova senha e Confirmar nova senha inválida");

            usuarioLogado.AlterarSenha(model.NovaSenha, model.ConfirmarNovaSenha);

            _context.Update(usuarioLogado);
            _context.SaveChanges();

            return Ok();
        }
    }
}
