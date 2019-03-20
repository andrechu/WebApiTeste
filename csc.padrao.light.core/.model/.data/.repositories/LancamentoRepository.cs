using csc.padrao.light.core.model.data.contexts;
using csc.padrao.light.core.model.entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csc.padrao.light.core.model.data.repositories
{
    public class LancamentoRepository : RepositoryBase<Lancamento>
    {
        public LancamentoRepository(DBServerContext contexto):base(contexto)
        {

        }

        public List<Lancamento> InserirLancamento(Lancamento lancamento)
        {
            var lista = new List<Lancamento>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                string command = $"exec[dbo].[sp_lancamento_inserir] {lancamento.Id_Conta_Origem}, {lancamento.Id_Conta_Destino}, {lancamento.Valor}";
                lista = connection.Query<Lancamento>(command).ToList();
            }

            return lista;
        }

    }
}
