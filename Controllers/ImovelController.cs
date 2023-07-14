using Entities;
using Imobiliaria.Infra;
using Imobiliaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imobiliaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly IConfiguration _config;
        protected readonly ImobiliariaContext context;

        public ImovelController(ImobiliariaContext context, IConfiguration config)
        {
            _config = config;
            this.context = context;
        }

        [HttpPost]
        [Route("salvar")]
        public IActionResult Salvar([FromBody] ImovelModel model)
        {
            Imovel imovel;

            if (model.IdImovel > 0)
            {
                imovel = context.Imoveis
                    .Include(i => i.Usuario)
                    .FirstOrDefault(x => x.IdImovel == model.IdImovel);

                if (imovel == null)
                    return BadRequest("Imóvel não encontrado");

                imovel.Alterar(model.NomeImovel, model.NQuarto, model.NBanheiro, model.NVagasGaragem, model.MetrosQuadrados,
                    model.ValorAluguel, model.ValorCondominio, model.ValorIptu, model.Locado, model.Cep,
                    model.Estado, model.Cidade, model.Bairro, model.Logradouro, model.Numero, model.Complemento,
                    model.Referencia, imovel.Usuario);

                context.Update(imovel);
            }
            else
            {
                var usuario = context.Usuario.FirstOrDefault(u => u.IdUsuario == model.Usuario.IdUsuario);
                if (usuario == null)
                {
                    return BadRequest("Usuário não encontrado");
                }

                imovel = new Imovel(model.NomeImovel, model.NQuarto, model.NBanheiro, model.NVagasGaragem,
                    model.MetrosQuadrados, model.ValorAluguel, model.ValorCondominio, model.ValorIptu,
                    model.Locado, model.Cep, model.Estado, model.Cidade, model.Bairro, model.Logradouro,
                    model.Numero, model.Complemento, model.Referencia, usuario);

                context.Imoveis.Add(imovel);
            }

            context.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("listar")]
        public IActionResult Listar([FromBody] FiltroImovel model)
        {
            Expression<Func<Imovel, bool>> filtroNQuarto = registro => true;
            Expression<Func<Imovel, bool>> filtroNBanheiro = registro => true;
            Expression<Func<Imovel, bool>> filtroNVagasGaragem = registro => true;
            Expression<Func<Imovel, bool>> filtroMetrosQuadrados = registro => true;
            Expression<Func<Imovel, bool>> filtroValorAluguel = registro => true;
            Expression<Func<Imovel, bool>> filtroValorCondominio = registro => true;
            Expression<Func<Imovel, bool>> filtroValorIptu = registro => true;
            Expression<Func<Imovel, bool>> filtroCep = registro => true;
            Expression<Func<Imovel, bool>> filtroEstado = registro => true;
            Expression<Func<Imovel, bool>> filtroCidade = registro => true;
            Expression<Func<Imovel, bool>> filtroBairro = registro => true;
            Expression<Func<Imovel, bool>> filtroLogradouro = registro => true;

            if (model.NQuarto > 0)
                filtroNQuarto = (Imovel registro) => registro.NQuarto.Equals(model.NQuarto);

            if (model.NBanheiro > 0)
                filtroNBanheiro = (Imovel registro) => registro.NBanheiro.Equals(model.NBanheiro);

            if (model.NVagasGaragem > 0)
                filtroNVagasGaragem = (Imovel registro) => registro.NVagasGaragem.Equals(model.NVagasGaragem);

            if (model.ValorAluguel > 0)
                filtroValorAluguel = (Imovel registro) => registro.ValorAluguel.Equals(model.ValorAluguel);

            if (model.ValorCondominio > 0)
                filtroValorCondominio = (Imovel registro) => registro.ValorCondominio.Equals(model.ValorCondominio);

            if (model.ValorIptu > 0)
                filtroValorIptu = (Imovel registro) => registro.ValorIptu.Equals(model.ValorIptu);

            if (!string.IsNullOrEmpty(model.MetrosQuadrados))
                filtroMetrosQuadrados = (Imovel registro) => registro.MetrosQuadrados.Equals(model.MetrosQuadrados);

            if (!string.IsNullOrEmpty(model.Cep))
                filtroCep = (Imovel registro) => registro.Cep.Contains(model.Cep);

            if (!string.IsNullOrEmpty(model.Estado))
                filtroEstado = (Imovel registro) => registro.Estado.Contains(model.Estado);

            if (!string.IsNullOrEmpty(model.Cidade))
                filtroCidade = (Imovel registro) => registro.Cidade.Contains(model.Cidade);

            if (!string.IsNullOrEmpty(model.Bairro))
                filtroBairro = (Imovel registro) => registro.Bairro.Contains(model.Bairro);

            if (!string.IsNullOrEmpty(model.Logradouro))
                filtroLogradouro = (Imovel registro) => registro.Logradouro.Contains(model.Logradouro);

            var resultado = context.Imoveis
                .Include(i => i.Usuario)
                .Where(filtroNQuarto)
                .Where(filtroNBanheiro)
                .Where(filtroNVagasGaragem)
                .Where(filtroValorAluguel)
                .Where(filtroValorCondominio)
                .Where(filtroValorIptu)
                .Where(filtroMetrosQuadrados)
                .Where(filtroCep)
                .Where(filtroEstado)
                .Where(filtroCidade)
                .Where(filtroBairro)
                .Where(filtroLogradouro)
                .Select(m => new
                {
                    IdImovel = m.IdImovel,
                    Nome = m.Usuario.Nome,
                    Cpf = m.Usuario.Cpf,
                    NomeImovel = m.NomeImovel,
                    MetrosQuadrados = m.MetrosQuadrados,
                    NQuarto = m.NQuarto,
                    NVagasGaragem = m.NVagasGaragem,
                    NBanheiro = m.NBanheiro,
                    ValorLocacao = m.ValorAluguel,
                    Estado = m.Estado,
                    Cidade = m.Cidade,
                    Bairro = m.Bairro,
                    Logradouro = m.Logradouro,
                    Numero = m.Numero,
                    Complemento = m.Complemento,
                    Referencia = m.Referencia,
                    Locado = m.Locado,
                    Usuario = m.Usuario.Nome,
                    Situacao = m.Situacao
                }).ToList();

            return Ok(resultado);
        }

        [HttpGet]
        [Route("obter")]
        public IActionResult Obter(int idImovel)
        {
            var resultado = context.Imoveis
            .Include(i => i.Usuario)
                .Select(m => new
                {
                    IdImovel = m.IdImovel,
                    Nome = m.Usuario.Nome,
                    Cpf = m.Usuario.Cpf,
                    NomeImovel = m.NomeImovel,
                    MetrosQuadrados = m.MetrosQuadrados,
                    NQuarto = m.NQuarto,
                    NVagasGaragem = m.NVagasGaragem,
                    NBanheiro = m.NBanheiro,
                    ValorLocacao = m.ValorAluguel,
                    Estado = m.Estado,
                    Cidade = m.Cidade,
                    Bairro = m.Bairro,
                    Logradouro = m.Logradouro,
                    Numero = m.Numero,
                    Complemento = m.Complemento,
                    Referencia = m.Referencia,
                    Locado = m.Locado,
                    Situacao = m.Situacao,
                }).FirstOrDefault(x => x.IdImovel == idImovel);

            return Ok(resultado);
        }

        // Função para alterar o status de venda ou aluguel de um imóvel existente
        [HttpPut]
        [Route("Imoveis/{id}/Negociar")]
        public IActionResult NegociarImovel(int id, [FromBody] NegociarImovelModel model)
        {
            // Verifica se o usuário existe
            var usuario = context.Usuario.FirstOrDefault(u => u.IdUsuario == model.IdUsuario);
            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado");
            }

            // Verifica se o imóvel existe
            var imovel = context.Imoveis.Include(i => i.Usuario).FirstOrDefault(i => i.IdImovel == id);
            if (imovel == null)
            {
                return BadRequest("Imóvel não encontrado");
            }

            // Realiza a negociação do imóvel (aluguel ou venda) alterando o status
            imovel.Locado = model.Locado;
            imovel.Vendido = !model.Locado;

            // Salva as alterações no imóvel
            context.Imoveis.Update(imovel);

            // Cria uma instância de Negociacao
            var negociacao = new Negociacao
            {
                ValorAluguel = model.ValorAluguel,
                ValorVenda = model.ValorVenda,
                ValorCondominio = model.ValorCondominio,
                ValorIptu = model.ValorIptu,
                DisponivelParaAluguel = model.DisponivelParaAluguel,
                DisponivelParaVenda = model.DisponivelParaVenda,
                Locado = model.Locado,
                Vendido = model.Vendido,
                IdImovel = imovel.IdImovel,
                Imovel = imovel,
                Usuario = usuario,
                IdUsuario = usuario.IdUsuario
            };

            // Associa a instância de Negociacao ao imóvel
            imovel.Negociacao = new List<Negociacao> { negociacao };

            // Salva as alterações no contexto
            context.Negociacao.Add(negociacao);
            context.SaveChanges();

            return Ok();
        }


        [HttpPost]
        [Route("alterarValor")]
        public IActionResult AlterarValor([FromBody] AlterarValorImovelModel model)
        {
            var imovel = context.Imoveis.Include(x => x.Usuario).FirstOrDefault(x => x.IdImovel == model.IdImovel);
            if (imovel == null)
                return BadRequest("Imóvel não encontrado");

            imovel.AlterarValorImovel(model.ValorAluguel, model.ValorCondominio, model.ValorIptu, imovel.Usuario);

            context.Update(imovel);
            context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("excluir")]
        public IActionResult Excluir(int idImovel)
        {
            var imovel = context.Imoveis.Include(x => x.Usuario).FirstOrDefault(x => x.IdImovel == idImovel);
            if (imovel == null)
                return BadRequest("Imóvel não encontrado");

            imovel.Excluir(User.Identity.Name);

            context.Update(imovel);
            context.SaveChanges();

            return Ok();
        }
    }
}