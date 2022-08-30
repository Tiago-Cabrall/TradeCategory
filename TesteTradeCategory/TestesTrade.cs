
using TradeCategory.Servicos;
using TradeCategory.Interfaces;
using TradeCategory.Model;
using TradeCategory.Repository;
using Moq;

namespace TesteTradeCategory
{
    public class TestesTrade
    {
        List<ITrade> ListaITrade = new List<ITrade>();        
        TradeModel trademodel;


        public TestesTrade()
        {
            CategoriaRepository.PopularCategoria();
        }


        [Fact]
        public void TestaCategoriaHighriskValorSuperior1000000ClinentePrivado()
        {

            //Arrange
            ListaITrade.Add(trademodel = new TradeModel
            {
                Valor = 2000000,
                SetorCliente = "Private",
                DataProximoPagamento = DateTime.ParseExact("12/29/2025", "MM/dd/yyyy", null),
                DataReferencia = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null)
            });

            //Act
            CategoriaRepository.GetCategoria(trademodel);

            //Assert
            Assert.Equal("HIGHRISK", trademodel.Category);
        }

        [Fact]
        public void TestaCategoriaExpiredDataPagamentoInferiorDaRef()
        {

            //Arrange
            ListaITrade.Add(trademodel = new TradeModel
            {
                Valor = 400000,
                SetorCliente = "Public",
                DataProximoPagamento = DateTime.ParseExact("07/01/2020", "MM/dd/yyyy", null),
                DataReferencia = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null)
            });

            //Act          
            CategoriaRepository.GetCategoria(trademodel);

            //Assert
            Assert.Equal("EXPIRED", trademodel.Category);
        }

        [Fact]
        public void TestaCategoriaHighriskValorSuperior1000000ClinentePublico()
        {

            //Arrange
            ListaITrade.Add(trademodel = new TradeModel
            {
                Valor = 5000000,
                SetorCliente = "Public",
                DataProximoPagamento = DateTime.ParseExact("01/01/2024", "MM/dd/yyyy", null),
                DataReferencia = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null)
               
            });

            //Act          
            CategoriaRepository.GetCategoria(trademodel);          

            //Assert
            Assert.Equal("MEDIUMRISK", trademodel.Category);
        }
        
        
        [Fact]
        public void TestaTratarString()
        {
            //Arrange            
            TradeServico tradeservico = new TradeServico();

            //Act
            ITrade trade = tradeservico.TratarString("1000000 Private 01/02/2028", DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", null));
         
            //Assert
            Assert.Equal("Private", trade.SetorCliente);
        }       
        
        
    }
}
