using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCategory.Model;

namespace TradeCategory.Repository
{
    public class CategoriaRepository
    {

        static List<CategoriaModel> listCategoria = new List<CategoriaModel>();
        public static void PopularCategoria()
        {
            listCategoria.Add(new CategoriaModel { Name = "HIGHRISK", Setor = "Private", valor = 1000000, DataBase = 30 });
            listCategoria.Add(new CategoriaModel { Name = "EXPIRED", Setor = "", valor = 0, DataBase = 30 });
            listCategoria.Add(new CategoriaModel { Name = "MEDIUMRISK", Setor = "Public", valor = 1000000, DataBase = 30 });
        }
        public static void GetCategoria(TradeModel trademodel)
        {
            var QDTDias = (trademodel.DataReferencia.Subtract(trademodel.DataProximoPagamento)).Days;
                       
                trademodel.Category = listCategoria.Where(x => QDTDias > x.DataBase ||
                                                          x.valor < trademodel.Valor &&
                                                          x.Setor == trademodel.SetorCliente).
                                                    OrderBy(x => x.valor).
                                                    Select(x => x.Name).
                                                    FirstOrDefault();

        }
    }
}
