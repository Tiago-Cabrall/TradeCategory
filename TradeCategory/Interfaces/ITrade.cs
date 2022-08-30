

namespace TradeCategory.Interfaces
{
    public interface ITrade
    {       
        public double Valor { get;  } 
        public string SetorCliente { get; }
        public DateTime DataProximoPagamento { get; }
        public DateTime DataReferencia { get; } 
        public string Category { get; set; }
               
    }
}
