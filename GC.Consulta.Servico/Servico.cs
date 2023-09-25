using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using GC.Consulta.Domain.Entidade.Util;
using GC.Consulta.Infra;
using GC.Consulta.Infra.Repositorio;
using static System.Net.Mime.MediaTypeNames;

namespace GC.Consulta.Servico
{
    public interface IServico<T> where T : Basico
    {
        Task<T> Salvar(T entidade);
        Task Inativar(long id);
        Task Ativar(long id);
        Task<T> BuscarPorId(long Id);
        Task<ListaPaginada<T>> Paginar(FiltroBase filtro, int pagina, int quantidade);
    }

    public class Servico<T> : IServico<T> where T : Basico, new()
    {
        protected readonly IRepositorio<T> repositorio;

        public Servico(IRepositorio<T> repository)
        {
            this.repositorio = repository;
        }

        public virtual async Task<T> Salvar(T entidade)
        {
            return await repositorio.Salvar(entidade);
        }

        public virtual async Task Inativar(long id)
        {
            await repositorio.Inativar(id);
        }

        public virtual async Task Ativar(long id)
        {
            await repositorio.Ativar(id);
        }

        public Task<T> BuscarPorId(long id)
        {
            return repositorio.BuscarPorId(id);
        }
        public async Task<ListaPaginada<T>> Paginar(FiltroBase filtro, int pagina, int quantidade)
        {
            var predicate = PredicateBuilder.True<T>();

            if (filtro.UsuarioAlteracaoId is not null) predicate = predicate.And(e => e.UsuarioAlteracaoId == filtro.UsuarioAlteracaoId);

            if (filtro.Id is not null) predicate = predicate.And(e => e.Id == filtro.Id);

            if (filtro.Nome is not null) predicate = predicate.And(e => e.Nome.Contains(filtro.Nome));

            return new ListaPaginada<T>(await repositorio.Paginar(predicate, pagina, quantidade), await repositorio.Total(predicate), quantidade, pagina);
        }
    }
}