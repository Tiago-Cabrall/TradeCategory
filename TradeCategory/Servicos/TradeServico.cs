
using System.Globalization;
using TradeCategory.Interfaces;
using TradeCategory.Model;
using TradeCategory.Repository;

namespace TradeCategory.Servicos
{
    public class TradeServico
    {



        public bool TrataElementosString(string Elemento)
        {
            double Valor;
            DateTime DateProximoPagamento;

            if (!double.TryParse(Elemento.Split(' ')[0], out Valor ))
            {
                Console.WriteLine(" - Insira um valor válido");                
                return false;
            }

            if ((Elemento.Split(' ')[1].ToUpper() != "PUBLIC") && (Elemento.Split(' ')[1].ToUpper() != "PRIVATE"))
            {
                Console.WriteLine(" - Insira um setor válido (Private ou Public)");              
                return false;
            }


            if (!DateTime.TryParseExact(Elemento.Split(' ')[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateProximoPagamento))
            {
                Console.WriteLine(" - Insira uma data válida nesse formato mm/dd/yyyy");                
                return false;
            }    

            return true;
        }

        public TradeModel TrataString(string Elemento, DateTime DataReferencia)
        {        
            TradeModel trademodel = new TradeModel
            {
                Valor = double.Parse(Elemento.Split(' ')[0]),
                SetorCliente = Elemento.Split(' ')[1],
                DataProximoPagamento = DateTime.ParseExact(Elemento.Split(' ')[2], "MM/dd/yyyy", null),
                DataReferencia = DataReferencia,

            };
                       
            return trademodel;
        }
                   
    }
}
