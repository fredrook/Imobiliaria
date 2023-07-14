namespace Entities
{
    public class Negociacao : BaseModel
    {
        public int IdImovelNegociacao { get; set; }
        public decimal ValorAluguel { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCondominio { get; set; }
        public decimal ValorIptu { get; set; }


        public bool? DisponivelParaAluguel { get; set; }
        public bool? DisponivelParaVenda { get; set; }
        public bool? Locado { get; set; }
        public bool? Vendido { get; set; }

        public int IdImovel { get; set; }
        public Imovel Imovel { get; set; }

        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
    }
}