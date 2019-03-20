using csc.padrao.light.core.model.data.contexts;
using csc.padrao.light.core.model.data.repositories;
using csc.padrao.light.core.model.entities;
using CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Resource;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC.PROJETO.PADRAO.LIGHT.APPLICATIONSERVICE.Services
{
    public class LancamentoApplicationService
    {
        private readonly LancamentoRepository _repository;
        private readonly ContaRepository _repositoryConta;

        public LancamentoApplicationService()
        {
            _repository = new LancamentoRepository(new DBServerContext());
            _repositoryConta = new ContaRepository(new DBServerContext());
        }

        public LancamentoResource InserirLancamento(LancamentoRequestResource lancamentoReq)
        {
            var listContaOrigem = _repositoryConta.ObterConta(TinyMapper.Map<Conta>(lancamentoReq.ContaOrigem));

            if (listContaOrigem==null || listContaOrigem.Count==0)
                throw new Exception("Conta Origem não Encontrada!");

            var contaOrigem = TinyMapper.Map<ContaResource>(listContaOrigem.FirstOrDefault());

            var listContaDestino = _repositoryConta.ObterConta(TinyMapper.Map<Conta>(lancamentoReq.ContaDestino));

            if (listContaDestino == null || listContaOrigem.Count == 0)
                throw new Exception("Conta Destino não Encontrada!");

            var contaDestino = TinyMapper.Map<ContaResource>(listContaDestino.FirstOrDefault());

            var lancamento = new LancamentoResource(contaOrigem, contaDestino, lancamentoReq.valor);

            var listLancamento = _repository.InserirLancamento(TinyMapper.Map<Lancamento>(lancamento));
            if (listLancamento == null || listLancamento.Count == 0)
                throw new Exception("Erro ao Inserir Lançamento!");

            lancamento.Id = listLancamento.FirstOrDefault().Id;
            lancamento.Data = listLancamento.FirstOrDefault().Data;

            return lancamento;

        }
        
    }
}
