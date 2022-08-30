
using TradeCategory.Servicos;
using TradeCategory.Interfaces;
using TradeCategory.Model;
using TradeCategory.Repository;
using System.Globalization;

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
            DateTime DataReferencia;
            int QtdeTrade;

            Console.Write("Data Referência (Formato: mm/dd/yyyy):");
        
            while (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DataReferencia ))
            {
                Console.WriteLine(" - Insira uma data válida nesse formato mm/dd/yyyy");
                Console.Write("Data Referência (Formato: mm/dd/yyyy):");
            }           

            Console.WriteLine("");
            Console.Write("Insira o número de negócios na carteira: ");                       

            while (!int.TryParse(Console.ReadLine(), out QtdeTrade))
            {
                Console.WriteLine(" - Insira apena número inteiro");
                Console.Write("Insira o número de negócios na carteira: ");
            }

            Console.WriteLine("");
            Console.WriteLine("[Valor da negociação] [Setor do cliente] [Data do próximo pagamento pendente(Formato: mm/dd/yyyy):");

            for (int i = 0; i < QtdeTrade; i++)
            {
                Console.Write(i+1 + " de " + QtdeTrade + " - ");

                var LineString = Console.ReadLine();

                
                if (tradeservico.TrataElementosString(LineString))
                {
                    trademodel = tradeservico.TrataString(LineString, DataReferencia);
                    ListaITrade.Add(trademodel);

                    CategoriaRepository.GetCategoria(trademodel);
                }
                    else
                        i = i - 1;

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