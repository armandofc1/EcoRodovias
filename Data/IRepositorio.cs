using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Data
{    public interface IRepositorio<T> where T : class
    {
        IList<T> PesquisarTodos();
        T PesquisarPorCodigo(long id);
        IList<T> PesquisarPorNome(string nome);
        void Inserir(T entity);
        void InserirVarios(List<T> entities);
        void Atualizar(T entity);
        void AtualizarVarios(List<T> entities);
        void Excluir(T entity);
        void ExcluirVarios(List<T> entities);
    }
}