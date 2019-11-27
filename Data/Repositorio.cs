using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {

        public IList<T> PesquisarTodos()
        {
            using (var context = new GenericContext<T>())
            {
                var all = context.Entity.OrderBy(x => x.Codigo).ToList();
                return all;
            }
        }

        public IList<T> PesquisarPorCodigo(long codigo)
        {
            using (var context = new GenericContext<T>())
            {
                var all = context.Entity.Where(x => x.Codigo == codigo).OrderBy(x => x.Codigo).ToList();
                return all;
            }
        }

        public virtual void Inserir(T entity)
        {
            using (var context = new GenericContext<T>())
            {
                context.Entity.Add(entity);
                context.SaveChanges();
            }
        }

        public void InserirVarios(List<T> entities)
        {
            using (var context = new GenericContext<T>())
            {
                context.Entity.AddRange(entities);
                context.SaveChanges();
            }
        }

        public void Atualizar(T entity)
        {
            using (var context = new GenericContext<T>())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public void AtualizarVarios(List<T> entities)
        {
            using (var context = new GenericContext<T>())
            {
                context.UpdateRange(entities);
                context.SaveChanges();
            }
        }

        public void Excluir(T entity)
        {
            using (var context = new GenericContext<T>())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public void ExcluirVarios(List<T> entities)
        {
            using (var context = new GenericContext<T>())
            {
                context.RemoveRange(entities);
                context.SaveChanges();
            }
        }
    }
}