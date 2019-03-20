using csc.padrao.light.core.model.entities.bases;
using Dommel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace csc.padrao.light.core.model.data.repositories
{
    public class RepositoryBase<T> : IDisposable where T : class
    {
        private readonly BaseContext _context;
        protected readonly string ConnectionString;

        public RepositoryBase(BaseContext context)
        {
            _context = context;
            ConnectionString = _context.ConnectionString;
        }

        public object Adicionar(T entity)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return connection.Insert<T>(entity);
            }
        }

        public void Atualizar(T entity)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Update<T>(entity);
            }
        }

        public void Deletar(int id)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                var entidade = connection.Get<T>(id);
                if (entidade != null)
                {
                    connection.Delete<T>(entidade);
                }
            }
        }

        public List<T> Listar(Expression<Func<T, bool>> predicate)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return connection.Select<T>(predicate).ToList();
            }
        }

        public List<T> ListarTodos()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return connection.GetAll<T>().ToList();
            }
        }

        public T RetornarPorId(int id)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
