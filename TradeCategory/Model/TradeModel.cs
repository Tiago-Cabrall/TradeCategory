using TradeCategory.Interfaces;

namespace TradeCategory.Model
{
    public class TradeModel : ITrade
    {   
        public double Valor { get; set; } 
        public string SetorCliente { get; set; } 
        public DateTime DataProximoPagamento { get; set; } 
        public string Category { get; set; } 
        public DateTime DataReferencia { get; set; }
    }
}
