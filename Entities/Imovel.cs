using System.Collections.ObjectModel;

namespace Entities
{
    public class Imovel : BaseModel
    {
        public int IdImovel { get; set; }
        public string NomeImovel { get; set; }
        public int NQuarto { get; set; }
        public int NBanheiro { get; set; }
        public int NVagasGaragem { get; set; }
        public string MetrosQuadrados { get; set; }

        public decimal ValorAluguel { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCondominio { get; set; }
        public decimal ValorIptu { get; set; }

        public bool? Locado { get; set; }
        public bool? Vendido { get; set; }

        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public bool? DisponivelParaAluguel { get; set; }
        public bool? DisponivelParaVenda { get; set; }

        public ICollection<Negociacao> Negociacao { get; set; }


        public Imovel() { }

        public Imovel(string nomeImovel, int nQuarto, int nBanheiro, int nVagasGaragem,
            string metrosQuadrados, decimal valorAluguel, decimal valorCondominio, decimal valorIptu,
            bool locado, string cep, string estado, string cidade, string bairro, string logradouro,
            string numero, string complemento, string referencia, Usuario usuarioInclusao)
        {
            this.NomeImovel = nomeImovel;
            this.NQuarto = nQuarto;
            this.NBanheiro = nBanheiro;
            this.NVagasGaragem = nVagasGaragem;
            this.MetrosQuadrados = metrosQuadrados;
            this.ValorAluguel = valorAluguel;
            this.ValorCondominio = valorCondominio;
            this.ValorIptu = valorIptu;
            this.Locado = locado;
            this.Cep = cep;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Referencia = referencia;
            this.Usuario = usuarioInclusao;
            Valida();
        }

        public void Alterar(string nomeImovel, int nQuarto, int nBanheiro, int nVagasGaragem,
            string metrosQuadrados, decimal valorAluguel, decimal valorCondominio, decimal valorIptu,
            bool locado, string cep, string estado, string cidade, string bairro, string logradouro,
            string numero, string complemento, string referencia, Usuario usuarioAlteracao)
        {
            this.NomeImovel = nomeImovel;
            this.NQuarto = nQuarto;
            this.NBanheiro = nBanheiro;
            this.NVagasGaragem = nVagasGaragem;
            this.MetrosQuadrados = metrosQuadrados;
            this.ValorAluguel = valorAluguel;
            this.ValorCondominio = valorCondominio;
            this.ValorIptu = valorIptu;
            this.Locado = locado;
            this.Cep = cep;
            this.Estado = estado;
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Referencia = referencia;
            this.Usuario = usuarioAlteracao;
            Valida();
        }

        public void AlugarIImovel(Negociacao aluguel)
        {
            if (this.Negociacao == null)
                this.Negociacao = new Collection<Negociacao>();
            else if (this.Negociacao.Contains(aluguel))
                return;

            this.Negociacao.Add(aluguel);
        }

        public void VenderIImovel(Negociacao venda)
        {
            if (this.Negociacao == null)
                this.Negociacao = new Collection<Negociacao>();
            else if (this.Negociacao.Contains(venda))
                return;

            this.Negociacao.Add(venda);
        }

        public void AlterarValorImovel(decimal valorAluguel, decimal valorCondominio, decimal valorIptu, Usuario usuarioAlteracao)
        {
            this.ValorAluguel = valorAluguel;
            this.ValorCondominio = valorCondominio;
            this.ValorIptu = valorIptu;
            this.Usuario = usuarioAlteracao;
        }

        public void Valida()
        {
            if (string.IsNullOrEmpty(this.NomeImovel))
                throw new Exception("Campo nome é obrigatório");

            if (this.Usuario == null)
                throw new Exception("Usuário é obrigatório");
        }

        public void Excluir(string usuarioExclusao)
        {
            SetUsuarioExclusao(usuarioExclusao);
            Valida();
        }
    }
}