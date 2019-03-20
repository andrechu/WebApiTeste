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
    public class ContaRepository : RepositoryBase<Conta>
    {
        public ContaRepository(DBServerContext contexto):base(contexto)
        {

        }

        public List<Conta> ObterConta(Conta conta)
        {
            var lista = new List<Conta>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                string command = $"exec[dbo].[sp_conta_obter] '{conta.Banco}', {conta.Agencia}, {conta.CC}, {conta.Digito}";
                lista = connection.Query<Conta>(command).ToList();
            }

            return lista;
        }

        public List<Conta> InserirAlterarConta(Conta conta)
        {
            var lista = new List<Conta>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                string command = $"exec[dbo].[sp_conta_inserir] {conta.Banco}, {conta.Agencia}, {conta.CC}, {conta.Digito}, '{conta.Nome}'";
                lista = connection.Query<Conta>(command).ToList();
            }

            return lista;
        }

    }
}
