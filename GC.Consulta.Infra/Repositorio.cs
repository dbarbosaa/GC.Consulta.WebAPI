    using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GC.Consulta.Domain.Entidade.Util;
using GC.Consulta.Infra.Context;

namespace GC.Consulta.Infra
{
    public interface IRepositorio<T> where T : Basico, new()
    {
        Task<T> Salvar(T entidade);
        Task Inativar(long id);
        Task Ativar(long id);
        Task<List<T>> Paginar(Expression<Func<T, bool>> query, int pagina = 1, int quantidade = 10);
        Task<int> Total(Expression<Func<T, bool>> query);
        Task<T> BuscarPorId(long id);

    }

    public class Repositorio<T> : IRepositorio<T> where T : Basico, new()
    {
        protected readonly DataBaseContext context;

        public Repositorio(DataBaseContext context)
        {
            this.context = context;
        }

        public virtual async Task<T> Salvar(T entidade)
        {
            if (entidade.Id == 0)
            {
                return await Inserir(entidade);
            }
            else
            {
                return await Alterar(entidade);
            }
        }

        private async Task<T> Inserir(T entidade)
        {
            entidade.DataCadastro = DateTime.Now;

            entidade.DataAlteracao = null;

            context.Entry(entidade).State = EntityState.Added;

            await Salvar();

            return entidade;
        }

        private async Task<T> Alterar(T entidade)
        {
            entidade.DataAlteracao = DateTime.Now;

            entidade.DataCadastro = DateTime.Now;

            context.Entry(entidade).State = EntityState.Modified;

            await Salvar();

            return entidade;
        }

        public virtual async Task Inativar(long id)
        {
            var entidade = context.Set<T>().Find(id);

            if (entidade is not null)
            {
                entidade.DataAlteracao = DateTime.Now;
                entidade.Status = 0;
                context.Entry(entidade).State = EntityState.Modified;
                await Salvar();
            }
        }

        public virtual async Task Ativar(long id)
        {
            var entidade = context.Set<T>().Find(id);

            if (entidade is not null)
            {
                entidade.DataAlteracao = DateTime.Now;
                entidade.Status = 1;
                context.Entry(entidade).State = EntityState.Modified;
                await Salvar();
            }
        }

        public virtual Task<List<T>> Paginar(Expression<Func<T, bool>> query, int pagina = 1, int quantidade = 10)
        {
            return context.Set<T>().Where(query).Skip(((int)pagina - 1) * (int)quantidade).Take((int)quantidade).ToListAsync();
        }

        protected async Task Salvar()
        {
            await context.SaveChangesAsync();
        }

        public async Task<T> BuscarPorId(long id)
        {
            return context.Set<T>().Find(id);
        }

        public Task<int> Total(Expression<Func<T, bool>> query)
        {
            return context.Set<T>().Where(query).CountAsync();
        }
    }
}