namespace Imobiliaria.Models
{
    public class ImovelModel
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

        public bool Locado { get; set; }

        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public UsuarioModel.UsuarioCadastrarImovelModel Usuario { get; set; }
    }

    public class FiltroImovel
    {
        public int NQuarto { get; set; }
        public int NBanheiro { get; set; }
        public int NVagasGaragem { get; set; }
        public string MetrosQuadrados { get; set; }

        public decimal ValorAluguel { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCondominio { get; set; }
        public decimal ValorIptu { get; set; }

        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
    }

    public class AlterarValorImovelModel
    {
        public int IdImovel { get; set; }
        public decimal ValorAluguel { get; set; }
        public decimal ValorCondominio { get; set; }
        public decimal ValorIptu { get; set; }
    }

    public class NegociarImovelModel
    {
        public int IdUsuario { get; set; }
        public int IdImovel { get; set; }
        public decimal ValorAluguel { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCondominio { get; set; }
        public decimal ValorIptu { get; set; }

        public bool? DisponivelParaAluguel { get; set; }
        public bool? DisponivelParaVenda { get; set; }
        public bool? Locado { get; set; }
        public bool? Vendido { get; set; }

    }
}
