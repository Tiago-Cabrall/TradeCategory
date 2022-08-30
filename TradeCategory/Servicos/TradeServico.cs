
using TradeCategory.Interfaces;
using TradeCategory.Model;
using TradeCategory.Repository;

namespace TradeCategory.Servicos
{
    public class TradeServico
    {


        public TradeModel TratarString(string Elemento, DateTime DataReferencia)
        {
            TradeModel trademodel = new TradeModel
            {
                Valor = double.Parse(Elemento.Split(' ')[0]),
                SetorCliente = Elemento.Split(' ')[1],
                DataProximoPagamento = DateTime.ParseExact(Elemento.Split(' ')[2], "MM/dd/yyyy", null),
                DataReferencia = DataReferencia,

            };

            // CategoriaRepository.GetCategoria(trademodel);

            return trademodel;
        }
                   
    }
}
