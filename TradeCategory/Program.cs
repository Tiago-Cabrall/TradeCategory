
using TradeCategory.Servicos;
using TradeCategory.Interfaces;
using TradeCategory.Model;
using TradeCategory.Repository;

namespace TradeCategory
{
    class Program
    {
        static List<ITrade> ListaITrade = new List<ITrade>();

        static void Main(string[] args)
        {
            CategoriaRepository.PopularCategoria();
          
            Input();
            Output();
        }


        static void Input()
        {
           TradeModel trademodel;
           TradeServico tradeservico = new TradeServico();

            Console.Write("Data Referência (Format: mm/dd/yyyy):");
            var DataReferencia = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
            Console.WriteLine("");
            Console.Write("Insira o número de negócios na carteira: ");
            var QtdeTrade = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("[Valor da negociação] [Setor do cliente] [Data do próximo pagamento pendente(Formato: mm/dd/yyyy):");

            for (int i = 0; i < QtdeTrade; i++)
            {
                Console.Write(i+1 + " de " + QtdeTrade + " - ");

                trademodel = tradeservico.TratarString(Console.ReadLine(), DataReferencia);
                ListaITrade.Add(trademodel);

                CategoriaRepository.GetCategoria(trademodel);
            }

          
        }

        static void Output()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--> Categoria de Negociações: ");

            foreach (ITrade trade in ListaITrade)
            {
                Console.WriteLine(trade.Category);
            }

        }
    }
}